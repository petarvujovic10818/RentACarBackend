﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rentacar.data;

#nullable disable

namespace rentacar.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240407135333_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("rentacar.models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("gorivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("jacinaMotora")
                        .HasColumnType("int");

                    b.Property<string>("karoserija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marka")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("zapreminaMotora")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("rentacar.models.Feedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<string>("commentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDisliked")
                        .HasColumnType("bit");

                    b.Property<bool>("isLiked")
                        .HasColumnType("bit");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("carId");

                    b.HasIndex("userId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("rentacar.models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("bodovi")
                        .HasColumnType("int");

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<decimal>("cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumKraja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("carId");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("rentacar.models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("bodovi")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rentacar.models.Feedback", b =>
                {
                    b.HasOne("rentacar.models.Car", "car")
                        .WithMany("feedbacks")
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.models.User", "user")
                        .WithMany("feedbacks")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("rentacar.models.Order", b =>
                {
                    b.HasOne("rentacar.models.Car", "car")
                        .WithMany("orders")
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("user");
                });

            modelBuilder.Entity("rentacar.models.Car", b =>
                {
                    b.Navigation("feedbacks");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("rentacar.models.User", b =>
                {
                    b.Navigation("feedbacks");

                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
