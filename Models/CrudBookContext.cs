using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReactAspBooks.Models
{
    public partial class CrudBookContext : DbContext
    {

        public CrudBookContext(DbContextOptions<CrudBookContext> options)
            : base(options)
        {
            LoadDefaultBooks();
        }

        public virtual DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=kokorina\\sqlexpress;Database=CrudBook;Integrated Security=True");
            }
        }

        public List<Books> getBooks() => Books.Local.ToList<Books>();

        private void LoadDefaultBooks()
        {
            Books.Add(new Books { BookId = 100, BookName = "Alice in wonder", AuthorName = "Luice Carol" });
            Books.Add(new Books { BookId = 200, BookName = "Idiot", AuthorName = "Feodor Dostoevsky" });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__books__3DE0C207CFB115C2");

                entity.ToTable("books");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
