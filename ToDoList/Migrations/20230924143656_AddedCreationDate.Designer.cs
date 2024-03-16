﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoList.Database;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20230924143656_AddedCreationDate")]
    partial class AddedCreationDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Models.ToDoTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PerformerName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa6c6ed1-4f8b-4e82-928a-68583f0bcd51"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Написать приложение",
                            PerformerName = "Дамир",
                            Priority = 0,
                            State = 1,
                            Title = "Задача 1"
                        },
                        new
                        {
                            Id = new Guid("75ed8e1d-3eb5-470c-bfa0-c7aaa252b85f"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Подготовиться к контрольной",
                            PerformerName = "Дархан",
                            Priority = 0,
                            State = 0,
                            Title = "Задача 2"
                        },
                        new
                        {
                            Id = new Guid("1cb32819-c67c-49e0-bc91-88680e668fab"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Установить AD",
                            PerformerName = "Теипжан",
                            Priority = 1,
                            State = 1,
                            Title = "Задача 3"
                        },
                        new
                        {
                            Id = new Guid("ffb87d15-37ec-4e29-bdf3-60c1dc86d35a"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Посмотреть вебинар",
                            PerformerName = "Димаш",
                            Priority = 2,
                            State = 1,
                            Title = "Задача 4"
                        },
                        new
                        {
                            Id = new Guid("3f6fa61a-2b33-460b-8ead-21de769fa62f"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Создать БД",
                            PerformerName = "Данияр",
                            Priority = 2,
                            State = 2,
                            Title = "Задача 5"
                        },
                        new
                        {
                            Id = new Guid("06fecb40-ba73-40d8-8b04-5335d3f74712"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Создать модели",
                            PerformerName = "Адилет",
                            Priority = 1,
                            State = 2,
                            Title = "Задача 6"
                        },
                        new
                        {
                            Id = new Guid("7d6afeb8-a747-4453-ba7e-edd896fdb7af"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Создать контроллер",
                            PerformerName = "Алихан",
                            Priority = 1,
                            State = 0,
                            Title = "Задача 7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
