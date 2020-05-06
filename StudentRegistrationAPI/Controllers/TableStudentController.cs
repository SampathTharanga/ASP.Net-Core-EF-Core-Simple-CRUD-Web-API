using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationAPI.Models;

namespace StudentRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableStudentController : ControllerBase
    {
        private readonly StudentRegDBContext _context;

        public TableStudentController(StudentRegDBContext context)
        {
            _context = context;
        }

        // GET: api/TableStudent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableStudent>>> GetTableStudent()
        {
            return await _context.TableStudent.ToListAsync();
        }

        // GET: api/TableStudent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableStudent>> GetTableStudent(int id)
        {
            var tableStudent = await _context.TableStudent.FindAsync(id);

            if (tableStudent == null)
            {
                return NotFound();
            }

            return tableStudent;
        }

        // PUT: api/TableStudent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableStudent(int id, TableStudent tableStudent)
        {
            if (id != tableStudent.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(tableStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableStudentExists(id))
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

        // POST: api/TableStudent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TableStudent>> PostTableStudent(TableStudent tableStudent)
        {
            _context.TableStudent.Add(tableStudent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableStudentExists(tableStudent.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTableStudent", new { id = tableStudent.StudentId }, tableStudent);
        }

        // DELETE: api/TableStudent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableStudent>> DeleteTableStudent(int id)
        {
            var tableStudent = await _context.TableStudent.FindAsync(id);
            if (tableStudent == null)
            {
                return NotFound();
            }

            _context.TableStudent.Remove(tableStudent);
            await _context.SaveChangesAsync();

            return tableStudent;
        }

        private bool TableStudentExists(int id)
        {
            return _context.TableStudent.Any(e => e.StudentId == id);
        }
    }
}
