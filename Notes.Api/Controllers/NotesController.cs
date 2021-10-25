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

        /// <summary>
        /// Returns all notes
        /// </summary>
        /// <returns>List of notes</returns>
        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return repository.All;
        }
        /// <summary>
        /// Returns note by Id
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns>Return note</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(int id)
        {
            var note = await repository.GetByIdAsync(id);
            if (note == null) return NotFound();
            return note;
        }
        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="note">Note body</param>
        /// <returns>Status code with action name and value</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            await repository.AddAsync(note);
            return CreatedAtAction(nameof(Create), note);
        }
        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="note">Note body</param>
        /// <returns>Returns no content</returns>

        [HttpPut]
        public async Task<IActionResult> Update(Note note)
        {
           
                
            await repository.UpdateAsync(note);
            return NoContent();
        }
        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>Returns no content</returns>
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
