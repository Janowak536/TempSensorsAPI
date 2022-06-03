﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TempSensors.Infrastructure.Data;

#nullable disable

namespace TempSensorsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220530103138_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TempSensorsAPI.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("TempSensorsAPI.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
