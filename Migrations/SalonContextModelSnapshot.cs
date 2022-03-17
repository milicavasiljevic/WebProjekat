﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace WebProjekat.Migrations
{
    [DbContext(typeof(SalonContext))]
    partial class SalonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jmbg")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.Property<int?>("UslugaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.HasIndex("UslugaId");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("Models.RadnikTermin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Datum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RadnikId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("TerminId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RadnikId");

                    b.HasIndex("TerminId");

                    b.ToTable("RadniciTermini");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("RezervisaniTerminId")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("RezervisaniTerminId");

                    b.HasIndex("SalonId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Saloni");
                });

            modelBuilder.Entity("Models.SalonUsluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.Property<int?>("UslugaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.HasIndex("UslugaId");

                    b.ToTable("SaloniUsluge");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("VremeDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VremeOd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Radnici")
                        .HasForeignKey("SalonId");

                    b.HasOne("Models.Usluga", "Usluga")
                        .WithMany("Radnici")
                        .HasForeignKey("UslugaId");

                    b.Navigation("Salon");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("Models.RadnikTermin", b =>
                {
                    b.HasOne("Models.Radnik", "Radnik")
                        .WithMany("Termini")
                        .HasForeignKey("RadnikId");

                    b.HasOne("Models.Termin", "Termin")
                        .WithMany("RadniciTermini")
                        .HasForeignKey("TerminId");

                    b.Navigation("Radnik");

                    b.Navigation("Termin");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.HasOne("Models.Korisnik", "Korisnik")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("Models.RadnikTermin", "RezervisaniTermin")
                        .WithMany()
                        .HasForeignKey("RezervisaniTerminId");

                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Rezervacije")
                        .HasForeignKey("SalonId");

                    b.Navigation("Korisnik");

                    b.Navigation("RezervisaniTermin");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Models.SalonUsluga", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Usluge")
                        .HasForeignKey("SalonId");

                    b.HasOne("Models.Usluga", "Usluga")
                        .WithMany("Saloni")
                        .HasForeignKey("UslugaId");

                    b.Navigation("Salon");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.Navigation("Termini");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Navigation("Radnici");

                    b.Navigation("Rezervacije");

                    b.Navigation("Usluge");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Navigation("RadniciTermini");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Navigation("Radnici");

                    b.Navigation("Saloni");
                });
#pragma warning restore 612, 618
        }
    }
}
