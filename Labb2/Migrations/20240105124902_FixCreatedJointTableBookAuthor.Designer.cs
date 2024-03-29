﻿// <auto-generated />
using System;
using Labb2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240105124902_FixCreatedJointTableBookAuthor")]
    partial class FixCreatedJointTableBookAuthor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2.Model.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<int?>("BookAuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.HasIndex("BookAuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Labb2.Model.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<int?>("BookAuthorID")
                        .HasColumnType("int");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("BookAuthorID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Labb2.Model.BookAuthor", b =>
                {
                    b.Property<int>("BookAuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookAuthorID"));

                    b.HasKey("BookAuthorID");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("Labb2.Model.BookCopy", b =>
                {
                    b.Property<int>("BookCopyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookCopyID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("BookCopyID");

                    b.HasIndex("BookID");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("Labb2.Model.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"));

                    b.Property<int>("BookCopyID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LoanDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LoanID");

                    b.HasIndex("BookCopyID");

                    b.HasIndex("UserID");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("Labb2.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibraryCard")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Labb2.Model.Author", b =>
                {
                    b.HasOne("Labb2.Model.BookAuthor", null)
                        .WithMany("Authors")
                        .HasForeignKey("BookAuthorID");

                    b.HasOne("Labb2.Model.Book", null)
                        .WithMany("Authors")
                        .HasForeignKey("BookID");
                });

            modelBuilder.Entity("Labb2.Model.Book", b =>
                {
                    b.HasOne("Labb2.Model.BookAuthor", null)
                        .WithMany("Books")
                        .HasForeignKey("BookAuthorID");
                });

            modelBuilder.Entity("Labb2.Model.BookCopy", b =>
                {
                    b.HasOne("Labb2.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Labb2.Model.Loan", b =>
                {
                    b.HasOne("Labb2.Model.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2.Model.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Labb2.Model.Book", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("Labb2.Model.BookAuthor", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Labb2.Model.User", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
