using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE4_group_A_backend.Entities;

namespace SE4_group_A_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : Controller
    {
        private readonly StudentManagementSystemContext _context;
        public AchievementController(StudentManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/GetAchievementByStudent
        [HttpGet("GetAchievementByStudent/{studentId}")]
        public async Task<ActionResult<IEnumerable<Achievement>>> GetAchievementByStudent(string studentId)
        {
            return await _context.Achievements.Where(x=>x.StudentId== studentId).ToListAsync();
        }

        // GET: api/Achievement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achievement>> GetAchievement(string id)
        {
            var achievement = await _context.Achievements.FindAsync(id);

            if (achievement == null)
            {
                return NotFound();
            }

            return achievement;
        }

        // PUT: api/Achievement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchievement(string id, Achievement achievement)
        {
            if (id != achievement.AchievementId)
            {
                return BadRequest();
            }

            _context.Entry(achievement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Achievements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achievement>> PostAchievement(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AchievementExists(achievement.AchievementId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAchievement", new { id = achievement.AchievementId }, achievement);
        }

        // DELETE: api/Achievements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(string id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }

            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchievementExists(string id)
        {
            return _context.Achievements.Any(e => e.AchievementId == id);
        }
    }
}
