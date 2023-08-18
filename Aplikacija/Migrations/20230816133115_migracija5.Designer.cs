﻿// <auto-generated />
using System;
using Aplikacija;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplikacija.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230816133115_migracija5")]
    partial class migracija5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aplikacija.Models.Author", b =>
                {
                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Aplikacija.Models.Book", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Aplikacija.Models.Book_Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.HasIndex("Book_AuthorId");

                    b.ToTable("Book_Authors");
                });

            modelBuilder.Entity("Aplikacija.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Aplikacija.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Aplikacija.Models.Publisher", b =>
                {
                    b.Property<string>("PublisherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Aplikacija.Models.Book", b =>
                {
                    b.HasOne("Aplikacija.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Aplikacija.Models.Book_Author", b =>
                {
                    b.HasOne("Aplikacija.Models.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Aplikacija.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Aplikacija.Models.Book_Author", null)
                        .WithMany("Book_Authors")
                        .HasForeignKey("Book_AuthorId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Aplikacija.Models.Author", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("Aplikacija.Models.Book_Author", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("Aplikacija.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
