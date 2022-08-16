﻿// <auto-generated />
using System;
using EducationPortal.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationPortal.Infrastructure.DB.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20220816130824_FixNaming")]
    partial class FixNaming
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DbCourseDbMaterial", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("DbCourseDbMaterial");
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.DbCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.DbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.Materials.DbMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DbMaterial");
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.Materials.DbArticleMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Infrastructure.DB.DbModels.Materials.DbMaterial");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DbArticleMaterial_PublicationDate");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DbArticleMaterial");
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.Materials.DbBookMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Infrastructure.DB.DbModels.Materials.DbMaterial");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberPages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("DbBookMaterial");
                });

            modelBuilder.Entity("EducationPortal.Infrastructure.DB.DbModels.Materials.DbVideoMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Infrastructure.DB.DbModels.Materials.DbMaterial");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Quality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DbVideoMaterial");
                });

            modelBuilder.Entity("DbCourseDbMaterial", b =>
                {
                    b.HasOne("EducationPortal.Infrastructure.DB.DbModels.DbCourse", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationPortal.Infrastructure.DB.DbModels.Materials.DbMaterial", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
