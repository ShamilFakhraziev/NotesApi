using Microsoft.EntityFrameworkCore;
using Notes.Data.Context.Configurations;
using Notes.Data.Models;

namespace Notes.Data.Context
{
    public class NotesDbContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
