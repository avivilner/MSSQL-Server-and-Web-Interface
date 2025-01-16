namespace Backend_API
{
	using CsvHelper;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Globalization;

	[ApiController]
	[Route("api/[controller]")]
	public class TermsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public TermsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("upload")]
		public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
		{
			if (file == null || file.Length == 0) {
				return BadRequest("No file uploaded.");
			}

			try {
				using var stream = file.OpenReadStream();
				using var reader = new StreamReader(stream);
				using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

				var records = csv.GetRecords<Entry>().ToList();

				foreach (var record in records) {
					if (!_context.Entries.Any(t => t.Term == record.Term)) {
						_context.Entries.Add(record);
					}
				}

				await _context.SaveChangesAsync();
				return Ok("File processed successfully.");
			}
			catch (DbUpdateException) {
				return Conflict("Duplicate values found.");
			}
			catch (Exception ex) {
				return BadRequest($"Error: {ex.Message}");
			}
		}

        [HttpGet("test")]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                // Create a test entry
                var testEntry = new Entry { Term = "TestTerm" };

                // Add the test entry to the database
                _context.Entries.Add(testEntry);
                _context.SaveChanges();

                // Retrieve the added entry
                var retrievedEntry = _context.Entries.FirstOrDefault(e => e.Term == "TestTerm");

                if (retrievedEntry != null)
                {
                    return Ok(new { Success = true, Data = retrievedEntry });
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Test term not found in the database." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

		[HttpPost]
		public async Task<IActionResult> AddTerm([FromBody] Entry entry)
		{
			_context.Entries.Add(entry);
			await _context.SaveChangesAsync(); // Ensure changes are saved
			return Ok(entry);
		}
	}
}
