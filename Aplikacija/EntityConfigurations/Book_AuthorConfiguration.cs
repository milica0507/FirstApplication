using Aplikacija.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.EntityConfigurations
{
    public class Book_AuthorConfiguration : IEntityTypeConfiguration<Book_Author>
    {
        public void Configure(EntityTypeBuilder<Book_Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            builder.HasOne(a => a.Author)
                .WithMany(aa => aa.Book_Authors)
                .HasForeignKey(ai => ai.AuthorId);
        }
    }
}
