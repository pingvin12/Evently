﻿// <auto-generated />
using ClientBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientBackend.Migrations
{
    [DbContext(typeof(MxchaziContext))]
    [Migration("20230219180943_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientBackend.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<decimal[]>("Capacity")
                        .HasColumnType("numeric[]")
                        .HasColumnName("capacity");

                    b.Property<string>("Country")
                        .HasColumnType("character varying")
                        .HasColumnName("country");

                    b.Property<string>("Location")
                        .HasColumnType("character varying")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("events_pk");

                    b.HasIndex(new[] { "Id" }, "events_id_idx")
                        .IsUnique();

                    b.ToTable("events", "events");
                });
#pragma warning restore 612, 618
        }
    }
}
