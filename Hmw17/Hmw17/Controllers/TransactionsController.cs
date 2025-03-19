using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hmw17.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(TransactionDbContext context) : ControllerBase
{
    private readonly TransactionDbContext _context = context;

    [HttpPost("upload-csv")]
    public async Task<IActionResult> UploadCsv()
    {
        using var reader = new StreamReader(Request.Body);
        var transactions = new List<Transaction>();
        var isFirstLine = true;
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (isFirstLine)
            {
                isFirstLine = false;
                continue;
            }

            var fields = line.Split(',');
            if (fields.Length < 7) continue;

            if (!Guid.TryParse(fields[0], out var transactionId) || !Guid.TryParse(fields[1], out var userId))
                return BadRequest($"Invalid GUID format in line: {line}");

            if (!decimal.TryParse(fields[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var amount))
                return BadRequest($"Invalid amount format: {fields[3]}");

            if (!DateTime.TryParse(fields[2], CultureInfo.InvariantCulture, DateTimeStyles.None, out var timestamp))
                return BadRequest($"Invalid date format: {fields[2]}");

            transactions.Add(new Transaction
            {
                Id = transactionId,
                UserId = userId,
                Timestamp = timestamp.ToUniversalTime(),
                Amount = amount,
                Category = fields[4],
                Description = fields[5],
                Merchant = fields[6]
            });

            if (transactions.Count >= 10000)
            {
                await _context.Transactions.AddRangeAsync(transactions);
                await _context.SaveChangesAsync();
                transactions.Clear();
            }
        }

        await _context.Transactions.AddRangeAsync(transactions);
        await _context.SaveChangesAsync();
        return Ok("CSV uploaded successfully");
    }

    [HttpGet("analysis-report")]
    public async Task<IActionResult> GetAnalysisReport()
    {
        var usersSummary = await _context.Transactions
            .GroupBy(t => t.UserId)
            .Select(g => new
            {
                user_id = g.Key,
                total_income = g.Where(t => t.Amount > 0).Sum(t => t.Amount),
                total_expense = g.Where(t => t.Amount < 0).Sum(t => t.Amount)
            }).ToListAsync();

        var topCategories = await _context.Transactions
            .GroupBy(t => t.Category)
            .Select(g => new { category = g.Key, transactions_count = g.Count() })
            .OrderByDescending(g => g.transactions_count)
            .Take(3)
            .ToListAsync();

        var highestSpender = await _context.Transactions
            .Where(t => t.Amount < 0)
            .GroupBy(t => t.UserId)
            .Select(g => new { user_id = g.Key, total_expense = g.Sum(t => t.Amount) })
            .OrderBy(g => g.total_expense)
            .FirstOrDefaultAsync();

        var report = new
        {
            users_summary = usersSummary,
            top_categories = topCategories,
            highest_spender = highestSpender
        };

        return Ok(JsonConvert.SerializeObject(report));
    }
}
