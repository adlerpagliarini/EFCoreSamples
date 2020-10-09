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
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.Developer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DevType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Motivation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DeveloperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Factor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId")
                        .IsUnique()
                        .HasFilter("[DeveloperId] IS NOT NULL");

                    b.ToTable("Motivation");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.TaskToDo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

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

            modelBuilder.Entity("SkillTaskToDo", b =>
                {
                    b.Property<long>("SkillsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TasksToDoId")
                        .HasColumnType("bigint");

                    b.HasKey("SkillsId", "TasksToDoId");

                    b.HasIndex("TasksToDoId");

                    b.ToTable("SkillTaskToDo");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.BackEndDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<string>("DatabasePreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DatabaseStack")
                        .HasColumnType("bit");

                    b.ToTable("BackEndDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FrontEndDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<bool>("MobileStack")
                        .HasColumnType("bit");

                    b.Property<string>("MobileSystem")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FrontEndDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FullStackDeveloper", b =>
                {
                    b.HasBaseType("EFCoreSamples.Domain.Developers.Developer");

                    b.Property<string>("CloudPreference")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FullStackDeveloper");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Motivation", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithOne("Motivation")
                        .HasForeignKey("EFCoreSamples.Domain.Motivation", "DeveloperId");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.TaskToDo", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithMany("TasksToDo")
                        .HasForeignKey("DeveloperId");
                });

            modelBuilder.Entity("SkillTaskToDo", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreSamples.Domain.TaskToDo", null)
                        .WithMany()
                        .HasForeignKey("TasksToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.BackEndDeveloper", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCoreSamples.Domain.Developers.BackEndDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FrontEndDeveloper", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCoreSamples.Domain.Developers.FrontEndDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.FullStackDeveloper", b =>
                {
                    b.HasOne("EFCoreSamples.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCoreSamples.Domain.Developers.FullStackDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("EFCoreSamples.Domain.ExtraMotivation", "ExtraMotivation", b1 =>
                        {
                            b1.Property<string>("FullStackDeveloperId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("ExtraFactor")
                                .HasColumnType("varchar(50)");

                            b1.HasKey("FullStackDeveloperId");

                            b1.ToTable("FullStackDeveloper");

                            b1.WithOwner()
                                .HasForeignKey("FullStackDeveloperId");
                        });

                    b.Navigation("ExtraMotivation");
                });

            modelBuilder.Entity("EFCoreSamples.Domain.Developers.Developer", b =>
                {
                    b.Navigation("Motivation");

                    b.Navigation("TasksToDo");
                });
#pragma warning restore 612, 618
        }
    }
}
