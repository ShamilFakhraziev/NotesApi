using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class NotesController : ControllerBase
    {
        private readonly IRepository<Note> repository;
        private readonly ILogger<NotesController> _logger;
        public NotesController(IRepository<Note> repository, ILogger<NotesController> logger)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "Injected into NotesController");
        }

        /// <summary>
        /// Returns all notes
        /// </summary>
        /// <returns>List of notes</returns>
        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            _logger.LogInformation("Getting all notes");
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
            _logger.LogInformation("Getting a note");
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
            _logger.LogInformation("Creating a note");
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
            _logger.LogInformation("Updating a note");
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
            _logger.LogInformation("Deleting a note");
            var note = await repository.GetByIdAsync(id);
            if (note == null) return NotFound();
            await repository.DeleteAsync(note);
            return NoContent();
        }
    }
}
