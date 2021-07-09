﻿// <auto-generated />
using System;
using HApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HApi.Migrations
{
    [DbContext(typeof(HContext))]
    partial class HContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("HApi.DataAccess.Entities.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MHZ")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumCores")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("UserId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FolderName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("FolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoreMhz")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MB")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemMhz")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumCores")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.HDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MB")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("HDDs");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CPUSlots")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PCISlots")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("RAMSlots")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SataSlots")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.NetworkCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kbs")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("NetworkCards");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Profile", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MB")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MHZ")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("RAMs");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password_SHA256")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProfileUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("ProfileUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.CPU", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Computer", null)
                        .WithMany("CPUs")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Computer", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Motherboard", "Motherboard")
                        .WithMany()
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HApi.DataAccess.Entities.User", null)
                        .WithMany("Computers")
                        .HasForeignKey("UserId");

                    b.Navigation("Motherboard");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.GPU", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Computer", null)
                        .WithMany("GPUs")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.HDD", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Computer", null)
                        .WithMany("HDDs")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.NetworkCard", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Computer", null)
                        .WithMany("NetworkCards")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.RAM", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Computer", null)
                        .WithMany("RAMs")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.User", b =>
                {
                    b.HasOne("HApi.DataAccess.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.Computer", b =>
                {
                    b.Navigation("CPUs");

                    b.Navigation("GPUs");

                    b.Navigation("HDDs");

                    b.Navigation("NetworkCards");

                    b.Navigation("RAMs");
                });

            modelBuilder.Entity("HApi.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Computers");
                });
#pragma warning restore 612, 618
        }
    }
}
