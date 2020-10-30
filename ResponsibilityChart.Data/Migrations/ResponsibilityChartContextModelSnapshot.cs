﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResponsibilityChart.Data;

namespace ResponsibilityChart.Data.Migrations
{
    [DbContext(typeof(ResponsibilityChartContext))]
    partial class ResponsibilityChartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResponsibilityChart.Api.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("ResponsibilityChart.Api.Models.ChildResponsibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildId")
                        .HasColumnType("int");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int?>("ResponsibilityId")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("WeekId")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ResponsibilityId");

                    b.ToTable("ChildResponsibilities");
                });

            modelBuilder.Entity("ResponsibilityChart.Api.Models.Responsibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("ResponsibilityChart.Api.Models.ChildResponsibility", b =>
                {
                    b.HasOne("ResponsibilityChart.Api.Models.Child", null)
                        .WithMany("ChildResponsibilities")
                        .HasForeignKey("ChildId");

                    b.HasOne("ResponsibilityChart.Api.Models.Responsibility", "Responsibility")
                        .WithMany()
                        .HasForeignKey("ResponsibilityId");
                });
#pragma warning restore 612, 618
        }
    }
}