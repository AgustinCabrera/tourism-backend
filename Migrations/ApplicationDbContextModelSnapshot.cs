﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tourismApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tourismApp.Models.Entities.Atraction", b =>
                {
                    b.Property<int>("AtractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AtractionId"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("AtractionId");

                    b.ToTable("Atraction");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Itinerary", b =>
                {
                    b.Property<int>("ItineraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItineraryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("RemainingBudget")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("ItineraryID");

                    b.HasIndex("UserId1");

                    b.ToTable("Itinerary");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.ItineraryAtraction", b =>
                {
                    b.Property<int>("ItineraryId")
                        .HasColumnType("integer");

                    b.Property<int>("AtractionId")
                        .HasColumnType("integer");

                    b.HasKey("ItineraryId", "AtractionId");

                    b.HasIndex("AtractionId");

                    b.ToTable("ItineraryAtraction");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.ItineraryPromotion", b =>
                {
                    b.Property<int>("ItineraryId")
                        .HasColumnType("integer");

                    b.Property<int>("PromotionId")
                        .HasColumnType("integer");

                    b.HasKey("ItineraryId", "PromotionId");

                    b.HasIndex("PromotionId");

                    b.ToTable("ItineraryPromotion");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Promotion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PricingStrategy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsUserAdmin")
                        .HasColumnType("boolean");

                    b.Property<decimal>("UserAvailableTime")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UserBudget")
                        .HasColumnType("numeric");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("UserGold")
                        .HasColumnType("numeric");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserPreferredAttractionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Itinerary", b =>
                {
                    b.HasOne("tourismApp.Models.Entities.User", "User")
                        .WithMany("Itineraries")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.ItineraryAtraction", b =>
                {
                    b.HasOne("tourismApp.Models.Entities.Atraction", "Atraction")
                        .WithMany("ItineraryAtractions")
                        .HasForeignKey("AtractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismApp.Models.Entities.Itinerary", "Itinerary")
                        .WithMany("ItineraryAtractions")
                        .HasForeignKey("ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atraction");

                    b.Navigation("Itinerary");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.ItineraryPromotion", b =>
                {
                    b.HasOne("tourismApp.Models.Entities.Itinerary", "Itinerary")
                        .WithMany("ItineraryPromotions")
                        .HasForeignKey("ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismApp.Models.Entities.Promotion", "Promotion")
                        .WithMany("ItineraryPromotions")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itinerary");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Atraction", b =>
                {
                    b.Navigation("ItineraryAtractions");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Itinerary", b =>
                {
                    b.Navigation("ItineraryAtractions");

                    b.Navigation("ItineraryPromotions");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.Promotion", b =>
                {
                    b.Navigation("ItineraryPromotions");
                });

            modelBuilder.Entity("tourismApp.Models.Entities.User", b =>
                {
                    b.Navigation("Itineraries");
                });
#pragma warning restore 612, 618
        }
    }
}
