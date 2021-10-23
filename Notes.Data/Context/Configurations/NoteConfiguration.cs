using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Data.Models;

namespace Notes.Data.Context.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.IsImportant).HasDefaultValue(false);
            builder.Property(p => p.Title).HasMaxLength(200);

            builder.HasData(new Note { Id = 1, Title = "Первая заметка", Content = "Заметка - это краткая запись о чем либо", IsImportant=false });
        }
    }
}
