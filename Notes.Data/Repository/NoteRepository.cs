using Notes.Data.Context;
using Notes.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Data.Repository
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotesDbContext context;
        public NoteRepository(NotesDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Note> All => context.Notes.ToList();

        public async Task AddAsync(Note entity)
        {
            await context.Notes.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note entity)
        {
            context.Notes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            return await context.Notes.FindAsync(id);
        }

        public async Task UpdateAsync(Note entity)
        {

            context.Notes.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
