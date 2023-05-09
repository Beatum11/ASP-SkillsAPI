using Microsoft.EntityFrameworkCore;
using SkillsAPI.Data.Models;

namespace SkillsAPI.Data.EF
{
    public class SkillsDbContext: DbContext
    {
        public SkillsDbContext(DbContextOptions<SkillsDbContext> options) 
                                                          : base(options)
        {

        }

        public DbSet<Skill> Skills { get; set; }

    }
}
