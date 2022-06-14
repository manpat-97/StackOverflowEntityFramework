﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflowEF.Entities;

#nullable disable

namespace StackOverflowEF.Migrations
{
    [DbContext(typeof(StackOverflowContext))]
    [Migration("20220528181840_ViewQuestionsScoreAdded")]
    partial class ViewQuestionsScoreAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StackOverflowEF.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "You can do it in dbContext class",
                            QuestionId = 1,
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9")
                        },
                        new
                        {
                            Id = 2,
                            Content = "You need to configure in Program.cs",
                            QuestionId = 2,
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9")
                        },
                        new
                        {
                            Id = 3,
                            Content = "You can just configure like this:",
                            QuestionId = 3,
                            UserId = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98")
                        },
                        new
                        {
                            Id = 4,
                            Content = "DateTimeOffset is a representation of instantaneous time.",
                            QuestionId = 4,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e")
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasCheckConstraint("CK_Comments_AnswerId_QuestionId_NotBothNull", "[QuestionId] IS NOT NULL OR [AnswerId] IS NOT NULL");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerId = 1,
                            Content = "Good",
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9")
                        },
                        new
                        {
                            Id = 2,
                            AnswerId = 2,
                            Content = "Wrong",
                            UserId = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98")
                        },
                        new
                        {
                            Id = 3,
                            Content = "Nice",
                            QuestionId = 2,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e")
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionId = 1,
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"),
                            Value = -1
                        },
                        new
                        {
                            Id = 2,
                            QuestionId = 2,
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"),
                            Value = 1
                        },
                        new
                        {
                            Id = 3,
                            QuestionId = 3,
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"),
                            Value = -1
                        },
                        new
                        {
                            Id = 4,
                            QuestionId = 2,
                            UserId = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"),
                            Value = 1
                        },
                        new
                        {
                            Id = 5,
                            QuestionId = 3,
                            UserId = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"),
                            Value = -1
                        },
                        new
                        {
                            Id = 7,
                            QuestionId = 4,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"),
                            Value = 1
                        },
                        new
                        {
                            Id = 8,
                            QuestionId = 2,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"),
                            Value = 1
                        },
                        new
                        {
                            Id = 9,
                            QuestionId = 2,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"),
                            Value = 1
                        },
                        new
                        {
                            Id = 10,
                            QuestionId = 3,
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"),
                            Value = -1
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(30000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "How to add indexes by using Fluent API?",
                            Title = "Entity Framework",
                            UserId = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9")
                        },
                        new
                        {
                            Id = 2,
                            Content = "How to configure services in ASP.NET Core?",
                            Title = "Asp .Net Core",
                            UserId = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98")
                        },
                        new
                        {
                            Id = 3,
                            Content = "How to add Rotativa.aspnetcore configuration in Program.cs instead of RotativaConfiguration.Setup(env); that was in Startup.cs in .NET 5 and below?",
                            Title = "Asp .Net Core MVC",
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e")
                        },
                        new
                        {
                            Id = 4,
                            Content = "What is the difference between a DateTime and a DateTimeOffset and when should one be used?",
                            Title = "DateTime vs DateTimeOffset",
                            UserId = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e")
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.QuestionTag", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTags");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            TagId = 3
                        },
                        new
                        {
                            QuestionId = 1,
                            TagId = 2
                        },
                        new
                        {
                            QuestionId = 2,
                            TagId = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            TagId = 2
                        },
                        new
                        {
                            QuestionId = 4,
                            TagId = 4
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Asp"
                        },
                        new
                        {
                            Id = 2,
                            Name = ".Net"
                        },
                        new
                        {
                            Id = 3,
                            Name = "EF"
                        },
                        new
                        {
                            Id = 4,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"),
                            Email = "user1@example.com",
                            Name = "MarianKowalski123"
                        },
                        new
                        {
                            Id = new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"),
                            Email = "user2@example.com",
                            Name = "UserDrugi2"
                        },
                        new
                        {
                            Id = new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"),
                            Email = "user3@example.com",
                            Name = "Batman3"
                        });
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Answer", b =>
                {
                    b.HasOne("StackOverflowEF.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowEF.Entities.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Comment", b =>
                {
                    b.HasOne("StackOverflowEF.Entities.Answer", "Answer")
                        .WithMany("Comments")
                        .HasForeignKey("AnswerId");

                    b.HasOne("StackOverflowEF.Entities.Question", "Question")
                        .WithMany("Comments")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("StackOverflowEF.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Point", b =>
                {
                    b.HasOne("StackOverflowEF.Entities.Question", "Question")
                        .WithMany("Points")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowEF.Entities.User", "User")
                        .WithMany("Points")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Question", b =>
                {
                    b.HasOne("StackOverflowEF.Entities.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.QuestionTag", b =>
                {
                    b.HasOne("StackOverflowEF.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowEF.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Answer", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("Points");
                });

            modelBuilder.Entity("StackOverflowEF.Entities.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("Points");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
