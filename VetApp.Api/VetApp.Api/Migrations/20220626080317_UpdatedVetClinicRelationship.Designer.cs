﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetApp.Api.Context;

#nullable disable

namespace VetApp.Api.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220626080317_UpdatedVetClinicRelationship")]
    partial class UpdatedVetClinicRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("VetApp.Api.Models.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("VetApp.Api.Models.Vet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClinicId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OccupationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("VetApp.Api.Models.VeterinaryVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfVisit")
                        .HasColumnType("TEXT");

                    b.Property<int>("VetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VetId");

                    b.ToTable("VeterinaryVisit");
                });

            modelBuilder.Entity("VetApp.Api.Models.Vet", b =>
                {
                    b.HasOne("VetApp.Api.Models.Clinic", "Clinic")
                        .WithMany("Vets")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("VetApp.Api.Models.VeterinaryVisit", b =>
                {
                    b.HasOne("VetApp.Api.Models.Vet", "Vet")
                        .WithMany("VeterinaryVisit")
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("VetApp.Api.Models.Clinic", b =>
                {
                    b.Navigation("Vets");
                });

            modelBuilder.Entity("VetApp.Api.Models.Vet", b =>
                {
                    b.Navigation("VeterinaryVisit");
                });
#pragma warning restore 612, 618
        }
    }
}
