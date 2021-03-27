﻿// <auto-generated />
using System;
using Intro3D.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intro3D.Infrastructure.Data.Migrations
{
    [DbContext(typeof(StudyContext))]
    partial class StudyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Intro3D.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(11);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Intro3D.Domain.Models.Student", b =>
                {
                    b.OwnsOne("Intro3D.Domain.Models.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StudentId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("County")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Province")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("StudentId");

                            b1.ToTable("Students");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
