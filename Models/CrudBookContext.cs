using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactAspBooks.Models
{
    public partial class CrudBookContext : DbContext
    {

        public CrudBookContext(DbContextOptions<CrudBookContext> options)
            : base(options)
        {
           // LoadDefaultBooks();
        }

        public virtual DbSet<Books> Books { get; set; }

      //  public List<Books> getBooks() => Books.Local.ToList<Books>();

        //private void LoadDefaultBooks()
        //{
        //    Books.Add(new Books { BookId = 1, BookName = "Alice in wonder", AuthorName = "Luice Carol" });
        //    Books.Add(new Books { BookId = 2, BookName = "Idiot", AuthorName = "Feodor Dostoevsky" });
        //}

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
