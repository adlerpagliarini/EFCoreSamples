﻿// <auto-generated />
using System;
using EFCoreSamples.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreSamples.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.Developer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DevType")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Developer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Developer");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("TaskToDoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TaskToDoId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.TaskToDo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeveloperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("TaskToDo");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.BackEndDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<string>("DatabasePreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DatabaseStack")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("BackEndDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FrontEndDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<bool>("MobileStack")
                        .HasColumnType("bit");

                    b.Property<string>("MobileSystem")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FrontEndDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FullStackDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<string>("CloudPreference")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FullStackDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Skill", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.TaskToDo", null)
                        .WithMany("Skills")
                        .HasForeignKey("TaskToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSamples.Domain.TaskToDo", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithMany("TasksToDo")
                        .HasForeignKey("DeveloperId");
                });
#pragma warning restore 612, 618
        }
    }
}
