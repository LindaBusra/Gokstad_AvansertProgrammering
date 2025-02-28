﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TodoApplikasjon.Migrations
{
    [DbContext(typeof(TodoAppDbContext))]
    [Migration("20241130204405_AddedTodos")]
    partial class AddedTodos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("TodoApplikasjonDel2.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description for Todo Oppgave-1",
                            IsCompleted = false,
                            Title = "Todo Oppgave-1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description for Todo Oppgave-2",
                            IsCompleted = false,
                            Title = "Todo Oppgave-2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description for Todo Oppgave-3",
                            IsCompleted = false,
                            Title = "Todo Oppgave-3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
