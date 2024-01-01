﻿// <auto-generated />
using System;
using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20240101200853_deneme")]
    partial class deneme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoktorKullanici", b =>
                {
                    b.Property<int>("DoktorlarDoktorID")
                        .HasColumnType("int");

                    b.Property<int>("KullanicilarKullaniciID")
                        .HasColumnType("int");

                    b.HasKey("DoktorlarDoktorID", "KullanicilarKullaniciID");

                    b.HasIndex("KullanicilarKullaniciID");

                    b.ToTable("DoktorKullanici");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"), 1L, 1);

                    b.Property<string>("DoktorAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HastaneID")
                        .HasColumnType("int");

                    b.Property<int?>("PolID")
                        .HasColumnType("int");

                    b.HasKey("DoktorID");

                    b.HasIndex("HastaneID");

                    b.HasIndex("PolID");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastaneler", b =>
                {
                    b.Property<int>("HastaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaneID"), 1L, 1);

                    b.Property<string>("HastaneAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IlcelerID")
                        .HasColumnType("int");

                    b.Property<int?>("SehirlerID")
                        .HasColumnType("int");

                    b.HasKey("HastaneID");

                    b.HasIndex("IlcelerID");

                    b.HasIndex("SehirlerID");

                    b.ToTable("Hastane");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Ilceler", b =>
                {
                    b.Property<int>("IlcelerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlcelerID"), 1L, 1);

                    b.Property<string>("IlceAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SehirlerID")
                        .HasColumnType("int");

                    b.HasKey("IlcelerID");

                    b.HasIndex("SehirlerID");

                    b.ToTable("Ilce");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"), 1L, 1);

                    b.Property<int>("AilehID")
                        .HasColumnType("int");

                    b.Property<string>("KullaniciAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KullaniciDogum")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciTC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Personel", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PID"), 1L, 1);

                    b.Property<string>("PPasword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PID");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.Property<int>("PolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolID"), 1L, 1);

                    b.Property<int>("HastaneID")
                        .HasColumnType("int");

                    b.Property<string>("PolAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PolID");

                    b.HasIndex("HastaneID");

                    b.ToTable("Poliklinik");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"), 1L, 1);

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<string>("RandevuSaat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RandevuTarih")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurID")
                        .HasColumnType("int");

                    b.HasKey("RandevuID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("TurID");

                    b.ToTable("Randevu");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Sehirler", b =>
                {
                    b.Property<int>("SehirlerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SehirlerID"), 1L, 1);

                    b.Property<string>("SehirAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SehirlerID");

                    b.ToTable("Sehirler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Tur", b =>
                {
                    b.Property<int>("TurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurID"), 1L, 1);

                    b.Property<string>("randevuAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurID");

                    b.ToTable("RandevuTur");
                });

            modelBuilder.Entity("DoktorKullanici", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Doktor", null)
                        .WithMany()
                        .HasForeignKey("DoktorlarDoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("KullanicilarKullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Hastaneler", "Hastane")
                        .WithMany("Doktorlar")
                        .HasForeignKey("HastaneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Poliklinik", "Pol")
                        .WithMany("Doktorlar")
                        .HasForeignKey("PolID");

                    b.Navigation("Hastane");

                    b.Navigation("Pol");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastaneler", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Ilceler", "Ilceler")
                        .WithMany("Hastaneler")
                        .HasForeignKey("IlcelerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Sehirler", "Sehir")
                        .WithMany("Hastaneler")
                        .HasForeignKey("SehirlerID");

                    b.Navigation("Ilceler");

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Ilceler", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Sehirler", "Sehirler")
                        .WithMany("Ilceler")
                        .HasForeignKey("SehirlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehirler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Hastaneler", "Hastane")
                        .WithMany("Poliklinikler")
                        .HasForeignKey("HastaneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Randevu", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Doktor", "Doktor")
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Kullanici", "Kullanici")
                        .WithMany("Randevular")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Tur", "Tur")
                        .WithMany("randevular")
                        .HasForeignKey("TurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Kullanici");

                    b.Navigation("Tur");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastaneler", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Poliklinikler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Ilceler", b =>
                {
                    b.Navigation("Hastaneler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Kullanici", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Sehirler", b =>
                {
                    b.Navigation("Hastaneler");

                    b.Navigation("Ilceler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Tur", b =>
                {
                    b.Navigation("randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
