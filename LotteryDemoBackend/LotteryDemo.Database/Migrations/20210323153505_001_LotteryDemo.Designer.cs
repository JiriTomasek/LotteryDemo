﻿// <auto-generated />
using System;
using LotteryDemo.Database.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LotteryDemo.Database.Migrations
{
    [DbContext(typeof(LotteryDemoDbContext))]
    [Migration("20210323153505_001_LotteryDemo")]
    partial class _001_LotteryDemo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LotteryDemo.Entities.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DrawDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrawNumber1")
                        .HasColumnType("int");

                    b.Property<int>("DrawNumber2")
                        .HasColumnType("int");

                    b.Property<int>("DrawNumber3")
                        .HasColumnType("int");

                    b.Property<int>("DrawNumber4")
                        .HasColumnType("int");

                    b.Property<int>("DrawNumber5")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Draws");
                });
#pragma warning restore 612, 618
        }
    }
}