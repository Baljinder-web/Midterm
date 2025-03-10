﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Midterm.Models;

#nullable disable

namespace Midterm.Migrations
{
    [DbContext(typeof(BookManagementContext))]
    [Migration("20241110023545_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Midterm.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAvailability")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "F. Scott Fitzgerald",
                            GenreId = "F",
                            IsAvailability = false,
                            Title = "The Great Gatsby",
                            Year = 1925
                        },
                        new
                        {
                            BookId = 2,
                            Author = " Yuval Noah Harari ",
                            GenreId = "NF",
                            IsAvailability = false,
                            Title = "Sapiens",
                            Year = 2011
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Frank Herbert",
                            GenreId = "M",
                            IsAvailability = true,
                            Title = "Dune Signs",
                            Year = 1965
                        },
                        new
                        {
                            BookId = 4,
                            Author = "United Brewn ",
                            GenreId = "SF",
                            IsAvailability = true,
                            Title = "The New York",
                            Year = 1865
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Smith",
                            GenreId = "K",
                            IsAvailability = false,
                            Title = "The Best Island",
                            Year = 1955
                        });
                });

            modelBuilder.Entity("Midterm.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "F",
                            Name = "Fiction"
                        },
                        new
                        {
                            GenreId = "NF",
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            GenreId = "SF",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            GenreId = "K",
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = "M",
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("Midterm.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasIssuedBook")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.HasIndex("BookId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            BookId = 2,
                            Email = "rhama@gmail.com",
                            HasIssuedBook = true,
                            Name = "Rhama",
                            PhoneNumber = "5366372763"
                        },
                        new
                        {
                            MemberId = 2,
                            Email = "Inska@gmail.com",
                            HasIssuedBook = false,
                            Name = "Inskia",
                            PhoneNumber = "6739554393"
                        },
                        new
                        {
                            MemberId = 3,
                            BookId = 5,
                            Email = "ruhan@gmail.com",
                            HasIssuedBook = true,
                            Name = "Rujan",
                            PhoneNumber = "3655533363"
                        },
                        new
                        {
                            MemberId = 4,
                            Email = "Yagtinka@gmail.com",
                            HasIssuedBook = false,
                            Name = "Yagnika",
                            PhoneNumber = "6435987393"
                        },
                        new
                        {
                            MemberId = 5,
                            BookId = 1,
                            Email = "Thisnb@gmail.com",
                            HasIssuedBook = true,
                            Name = "Thinsina",
                            PhoneNumber = "5366378883"
                        });
                });

            modelBuilder.Entity("Midterm.Models.Book", b =>
                {
                    b.HasOne("Midterm.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Midterm.Models.Member", b =>
                {
                    b.HasOne("Midterm.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
