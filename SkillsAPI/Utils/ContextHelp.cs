using Microsoft.EntityFrameworkCore;
using SkillsAPI.Data.EF;
using SkillsAPI.Data.Models;

namespace SkillsAPI.Utils
{
    public class ContextHelp
    {
        #region CHECKING CONTEXT

        public bool ContextCheck(SkillsDbContext _context)
        {
            return _context == null;
        }

        #endregion

        #region ADDING SKILLS
        public async Task AddAndSaveAsync(Skill skill, SkillsDbContext _context)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region REMOVING SKILLS

        public async Task RemoveAndSave(Skill skill, SkillsDbContext _context)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region FINDING SKILLS
        public async Task<Skill> FindSkillAsync(int id, SkillsDbContext _context)
        {
            return await _context.Skills.FindAsync(id); ;
        }

        public async Task<List<Skill>> FindSkillsAsync(SkillsDbContext _context)
        {
            return await _context.Skills.ToListAsync();
        }

        #endregion

        #region UPDATING USERS

        public async Task UpdateAndSave(Skill skill, SkillsDbContext _context)
        {
            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
