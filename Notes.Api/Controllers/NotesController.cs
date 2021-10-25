using Microsoft.AspNetCore.Mvc;
using Notes.Data.Models;
using Notes.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController:ControllerBase
    {
        private readonly IRepository<Note> repository;
        public NotesController(IRepository<Note> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return repository.All;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(int id)
        {
            var note = await repository.GetByIdAsync(id);
            if (note == null) return NotFound();
            return note;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            await repository.AddAsync(note);
            return CreatedAtAction(nameof(Create), note);
        } 

        [HttpPut]
        public async Task<IActionResult> Update(Note note)
        {
           
                
            await repository.UpdateAsync(note);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await repository.GetByIdAsync(id);
            if (note == null) return NotFound();
            await repository.DeleteAsync(note);
            return NoContent();
        }
    }
}
