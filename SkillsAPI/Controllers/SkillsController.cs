using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillsAPI.Data.EF;
using SkillsAPI.Data.Models;
using SkillsAPI.Utils;

namespace SkillsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        #region Basic set-up

        private readonly SkillsDbContext _context;
        private ContextHelp contextHelper;
        private bool contextIsNull;

        public SkillsController(SkillsDbContext context)
        {
            _context = context;
            contextHelper = new ContextHelp();
            contextIsNull = contextHelper.ContextCheck(_context);
        }

        #endregion

        #region GET METHODS

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetSkills()
        {
            return contextIsNull ? NotFound() :
                                  await contextHelper.FindSkillsAsync(_context);
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            if (contextIsNull)
                return NotFound();

            var user = await contextHelper.FindSkillAsync(id, _context);
            return user == null ? NotFound() : user;
        }

        #endregion

        #region PUT METHOD

        // PUT: api/Users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, Skill skill)
        {
            if (id != skill.Id)
                return BadRequest();

            if (!contextIsNull)
            {
                var skillToUpdate = await contextHelper.FindSkillAsync(id, _context);
                if (skillToUpdate == null)
                    return NotFound();
                else
                {
                    // Update the user properties
                    skillToUpdate.Name = skill.Name;
                    skillToUpdate.Description = skill.Description;

                    // Save the changes
                    await contextHelper.UpdateAndSave(skillToUpdate, _context);
                }
            }

            return Ok();
        }

        #endregion

        #region POST METHOD

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            if (!contextIsNull)
                await contextHelper.AddAndSaveAsync(skill, _context);
            else
                return StatusCode(500, "Database connection error.");

            return CreatedAtAction("GetUser", new { id = skill.Id }, skill);
        }

        #endregion

        #region DELETE METHOD

        // DELETE: api/Users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (contextIsNull)
                return NotFound();

            var skill = await contextHelper.FindSkillAsync(id, _context);

            if (skill == null)
                return NotFound();
            else
            {
                await contextHelper.RemoveAndSave(skill, _context);
                return Ok();
            }
        }

        #endregion


    }
}
