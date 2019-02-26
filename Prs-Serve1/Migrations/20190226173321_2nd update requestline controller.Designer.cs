﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prs_Serve1.Models;

namespace Prs_Serve1.Migrations
{
    [DbContext(typeof(PrsDbContext))]
    [Migration("20190226173321_2nd update requestline controller")]
    partial class _2ndupdaterequestlinecontroller
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prs_Serve1.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(30);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Prs_Serve1.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("DeliveryMode")
                        .HasMaxLength(80);

                    b.Property<string>("Description")
                        .HasMaxLength(80);

                    b.Property<string>("Justification")
                        .HasMaxLength(80);

                    b.Property<string>("RejectionReason")
                        .HasMaxLength(80);

                    b.Property<string>("Status")
                        .HasMaxLength(10);

                    b.Property<DateTime>("SubmittedDate");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Prs_Serve1.Models.RequestLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("RequestId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestLines");
                });

            modelBuilder.Entity("Prs_Serve1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Email")
                        .HasMaxLength(220);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsReviewer");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(12);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Prs_Serve1.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .HasMaxLength(30);

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<bool>("IsPreferred");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(12);

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Zip")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Prs_Serve1.Models.Product", b =>
                {
                    b.HasOne("Prs_Serve1.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Prs_Serve1.Models.Request", b =>
                {
                    b.HasOne("Prs_Serve1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Prs_Serve1.Models.RequestLine", b =>
                {
                    b.HasOne("Prs_Serve1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Prs_Serve1.Models.Request")
                        .WithMany("RequestLines")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
