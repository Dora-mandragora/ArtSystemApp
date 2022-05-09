﻿// <auto-generated />
using System;
using ArtSystemApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtSystemApp.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220429101112_RenameToString")]
    partial class RenameToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtSystemApp.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Confirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Confirmations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "free"
                        },
                        new
                        {
                            Id = 2,
                            Name = "paid"
                        });
                });

            modelBuilder.Entity("ArtSystemApp.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FormatId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Img")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "user"
                        },
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("ArtSystemApp.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "block"
                        },
                        new
                        {
                            Id = 1,
                            Name = "active"
                        });
                });

            modelBuilder.Entity("ArtSystemApp.Models.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("ArtSystemApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConfirmationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmationId");

                    b.HasIndex("ImageId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccessId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThemeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("FolderId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Access", b =>
                {
                    b.HasOne("ArtSystemApp.Models.User", "User")
                        .WithMany("Accesses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Folder", b =>
                {
                    b.HasOne("ArtSystemApp.Models.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Picture", b =>
                {
                    b.HasOne("ArtSystemApp.Models.Format", "Format")
                        .WithMany("Images")
                        .HasForeignKey("FormatId");

                    b.Navigation("Format");
                });

            modelBuilder.Entity("ArtSystemApp.Models.User", b =>
                {
                    b.HasOne("ArtSystemApp.Models.Confirmation", "Confirmation")
                        .WithMany("Users")
                        .HasForeignKey("ConfirmationId");

                    b.HasOne("ArtSystemApp.Models.Picture", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("ArtSystemApp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("ArtSystemApp.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId");

                    b.Navigation("Confirmation");

                    b.Navigation("Image");

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Work", b =>
                {
                    b.HasOne("ArtSystemApp.Models.Access", "Access")
                        .WithMany("Works")
                        .HasForeignKey("AccessId");

                    b.HasOne("ArtSystemApp.Models.Folder", "Folder")
                        .WithMany("Works")
                        .HasForeignKey("FolderId");

                    b.HasOne("ArtSystemApp.Models.Picture", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("ArtSystemApp.Models.Theme", "Theme")
                        .WithMany("Works")
                        .HasForeignKey("ThemeId");

                    b.HasOne("ArtSystemApp.Models.User", "User")
                        .WithMany("Works")
                        .HasForeignKey("UserId");

                    b.Navigation("Access");

                    b.Navigation("Folder");

                    b.Navigation("Image");

                    b.Navigation("Theme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Access", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Confirmation", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Folder", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Format", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Status", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ArtSystemApp.Models.Theme", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("ArtSystemApp.Models.User", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("Folders");

                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}