﻿// <auto-generated />
using System;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTD_Mentorship_Project.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=DB;Integrated Security=true");

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Street_Address");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("ZipCode")
                        .HasColumnType("int")
                        .HasColumnName("Zip_Code");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("AreaName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("AreaId");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Identity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("IdentityName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Identity_Name");

                    b.HasKey("Id");

                    b.ToTable("Identity", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.MentorMentee", b =>
                {
                    b.Property<int>("MentorMenteeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MentorMenteeId"));

                    b.Property<int>("MenteeId")
                        .HasColumnType("int");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("MentorMenteeId");

                    b.HasIndex("MenteeId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorMentee", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("Availability")
                        .HasMaxLength(200)
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Company")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DOB")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Degree")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FieldofWork")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("OngoingMentorship")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SelectedUserTypeId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("TermsofServiceCheckbox")
                        .HasMaxLength(200)
                        .HasColumnType("bit");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("IdentityId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.UserArea", b =>
                {
                    b.Property<int>("UserAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAreaId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserAreaId");

                    b.HasIndex("AreaId");

                    b.HasIndex("UserId");

                    b.ToTable("UserArea", (string)null);
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Address", b =>
                {
                    b.HasOne("DTD_Mentorship_Project.Models.User", "User")
                        .WithMany("Address")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Address_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.MentorMentee", b =>
                {
                    b.HasOne("DTD_Mentorship_Project.Models.User", "Mentee")
                        .WithMany("MentorMenteeMentees")
                        .HasForeignKey("MenteeId")
                        .IsRequired()
                        .HasConstraintName("FK_MentorMentee_Mentee");

                    b.HasOne("DTD_Mentorship_Project.Models.User", "Mentor")
                        .WithMany("MentorMenteeMentors")
                        .HasForeignKey("MentorId")
                        .IsRequired()
                        .HasConstraintName("FK_MentorMentee_Mentor");

                    b.Navigation("Mentee");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.User", b =>
                {
                    b.HasOne("DTD_Mentorship_Project.Models.Identity", "Identity")
                        .WithMany("Users")
                        .HasForeignKey("IdentityId")
                        .IsRequired()
                        .HasConstraintName("FK_User_IdentityId");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.UserArea", b =>
                {
                    b.HasOne("DTD_Mentorship_Project.Models.Area", "Area")
                        .WithMany("UserAreas")
                        .HasForeignKey("AreaId")
                        .IsRequired()
                        .HasConstraintName("FK_UserArea_Area");

                    b.HasOne("DTD_Mentorship_Project.Models.User", "User")
                        .WithMany("UserAreas")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserArea_User");

                    b.Navigation("Area");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Area", b =>
                {
                    b.Navigation("UserAreas");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.Identity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DTD_Mentorship_Project.Models.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("MentorMenteeMentees");

                    b.Navigation("MentorMenteeMentors");

                    b.Navigation("UserAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
