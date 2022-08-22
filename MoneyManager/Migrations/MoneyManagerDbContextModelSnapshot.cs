﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager.Infrastructure.DbContexts;

#nullable disable

namespace MoneyManager.Migrations
{
    [DbContext(typeof(MoneyManagerDbContext))]
    partial class MoneyManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("MoneyManager.Infrastructure.DTOs.OperationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AmountOfMoney")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeOfChange")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeOfOperation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
