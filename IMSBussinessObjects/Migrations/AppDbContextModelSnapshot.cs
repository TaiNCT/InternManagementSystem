﻿// <auto-generated />
using System;
using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMSBussinessObjects.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IMSBussinessObjects.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int?>("InternId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("InternId");

                    b.HasIndex("TeamId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("IMSBussinessObjects.Documents", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"), 1L, 1);

                    b.Property<byte[]>("DocumentData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.HasIndex("InternId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("IMSBussinessObjects.Intern", b =>
                {
                    b.Property<int>("InternId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InternId"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("CvUrl")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Gpa")
                        .HasColumnType("float");

                    b.Property<DateTime>("InternshipEndingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InternshipStartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("OverallSuccess")
                        .HasColumnType("int");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("PhotoUrl")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Uni")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("InternId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Interns");
                });

            modelBuilder.Entity("IMSBussinessObjects.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("InternId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationDate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeCode")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("InternId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("IMSBussinessObjects.Supervisor", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupervisorId"), 1L, 1);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SupervisorId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("IMSBussinessObjects.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("IMSBussinessObjects.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IMSBussinessObjects.Assignment", b =>
                {
                    b.HasOne("IMSBussinessObjects.Intern", "Intern")
                        .WithMany("Assignments")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMSBussinessObjects.Team", "Team")
                        .WithMany("Assignments")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("IMSBussinessObjects.Documents", b =>
                {
                    b.HasOne("IMSBussinessObjects.Intern", "Intern")
                        .WithMany("Documents")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");
                });

            modelBuilder.Entity("IMSBussinessObjects.Intern", b =>
                {
                    b.HasOne("IMSBussinessObjects.Team", "Team")
                        .WithMany("Interns")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMSBussinessObjects.User", "User")
                        .WithOne("Intern")
                        .HasForeignKey("IMSBussinessObjects.Intern", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IMSBussinessObjects.Notification", b =>
                {
                    b.HasOne("IMSBussinessObjects.Intern", "Intern")
                        .WithMany("Notifications")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMSBussinessObjects.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IMSBussinessObjects.Supervisor", b =>
                {
                    b.HasOne("IMSBussinessObjects.Team", "Team")
                        .WithMany("Supervisors")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMSBussinessObjects.User", "User")
                        .WithMany("Supervisors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IMSBussinessObjects.Intern", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Documents");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("IMSBussinessObjects.Team", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Interns");

                    b.Navigation("Supervisors");
                });

            modelBuilder.Entity("IMSBussinessObjects.User", b =>
                {
                    b.Navigation("Intern")
                        .IsRequired();

                    b.Navigation("Notifications");

                    b.Navigation("Supervisors");
                });
#pragma warning restore 612, 618
        }
    }
}
