﻿// <auto-generated />
using System;
using GoodWillApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoodWillApi.Data.Migrations
{
    [DbContext(typeof(GoodDbContext))]
    partial class GoodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoodWillApi.Models.BloodDonation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BagCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("BloodRequestId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BloodRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("BloodDonations");
                });

            modelBuilder.Entity("GoodWillApi.Models.BloodRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BagCount")
                        .HasColumnType("integer");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BloodRequests");
                });

            modelBuilder.Entity("GoodWillApi.Models.ManpowerDonation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ManpowerRequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("VolunteerCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ManpowerRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("ManpowerDonations");
                });

            modelBuilder.Entity("GoodWillApi.Models.ManpowerRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IncidentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("VolunteerCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ManpowerRequests");
                });

            modelBuilder.Entity("GoodWillApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoodWillApi.Models.BloodDonation", b =>
                {
                    b.HasOne("GoodWillApi.Models.BloodRequest", "BloodRequest")
                        .WithMany()
                        .HasForeignKey("BloodRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodWillApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoodWillApi.Models.BloodRequest", b =>
                {
                    b.HasOne("GoodWillApi.Models.User", "User")
                        .WithMany("BloodRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoodWillApi.Models.ManpowerDonation", b =>
                {
                    b.HasOne("GoodWillApi.Models.ManpowerRequest", "ManpowerRequest")
                        .WithMany()
                        .HasForeignKey("ManpowerRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodWillApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManpowerRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoodWillApi.Models.ManpowerRequest", b =>
                {
                    b.HasOne("GoodWillApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoodWillApi.Models.User", b =>
                {
                    b.Navigation("BloodRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
