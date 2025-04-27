// API/Controllers/SyncController.cs
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SyncController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("push")]
        public async Task<IActionResult> PushChanges([FromBody] List<ProductDto> changes)
        {
            foreach (var item in changes)
            {
                var existing = await _context.Products.FindAsync(item.Id);
                if (existing == null || existing.LastModified < item.LastModified)
                {
                    _context.Entry(existing ?? new Product()).CurrentValues.SetValues(item);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("pull")]
        public IActionResult PullChanges([FromQuery] long lastSync)
        {
            var changes = _context.Products
                .Where(p => p.LastModified > lastSync)
                .Select(p => new ProductDto {
                    Id = p.Id,
                    Name = p.Name,
                    LastModified = p.LastModified
                }).ToList();
            return Ok(changes);
        }
    }
}
