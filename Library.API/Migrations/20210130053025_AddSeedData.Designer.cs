﻿// <auto-generated />
using System;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.API.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20210130053025_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Library.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("BirthData")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e4a08daf-1ff5-40b9-b4ca-f1ed5ac868bf"),
                            BirthData = new DateTimeOffset(new DateTime(1993, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "上海",
                            Email = "author1@e.com",
                            Name = "author1"
                        },
                        new
                        {
                            Id = new Guid("a6053251-d1c6-4b9c-86be-a2fe8124a80f"),
                            BirthData = new DateTimeOffset(new DateTime(1994, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "北京",
                            Email = "author2@e.com",
                            Name = "author2"
                        },
                        new
                        {
                            Id = new Guid("058ddac3-c6f5-42c2-a8ec-4a8000802990"),
                            BirthData = new DateTimeOffset(new DateTime(1995, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "成都",
                            Email = "author3@e.com",
                            Name = "author3"
                        });
                });

            modelBuilder.Entity("Library.API.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("058ddac3-c6f5-42c2-a8ec-4a8000802990"),
                            AuthorId = new Guid("e4a08daf-1ff5-40b9-b4ca-f1ed5ac868bf"),
                            Description = "book1 Description",
                            Pages = 100,
                            Title = "book1 Title"
                        },
                        new
                        {
                            Id = new Guid("d64263c7-a382-482c-b773-ba74caa8f4a1"),
                            AuthorId = new Guid("a6053251-d1c6-4b9c-86be-a2fe8124a80f"),
                            Description = "book2 Description",
                            Pages = 100,
                            Title = "book2 Title"
                        },
                        new
                        {
                            Id = new Guid("7c75c7c4-1268-4d60-999b-686b08d3b269"),
                            AuthorId = new Guid("058ddac3-c6f5-42c2-a8ec-4a8000802990"),
                            Description = "book3 Description",
                            Pages = 100,
                            Title = "book3 Title"
                        });
                });

            modelBuilder.Entity("Library.API.Entities.Book", b =>
                {
                    b.HasOne("Library.API.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Library.API.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
