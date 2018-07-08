﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Notlifx.Data;
using System;

namespace Notlifx.Data.Migrations
{
    [DbContext(typeof(NotflixDbContext))]
    [Migration("20180708081627_Video_Table_Update")]
    partial class Video_Table_Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Notflix.Domain.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("GenderName");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Notflix.Domain.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsBooked");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<Guid?>("UserId");

                    b.Property<int>("Version");

                    b.Property<Guid?>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Notflix.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Notflix.Domain.UserHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid?>("UserId");

                    b.Property<int>("Version");

                    b.Property<Guid?>("VideoId");

                    b.Property<DateTime>("WatchDate");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("UserHistory");
                });

            modelBuilder.Entity("Notflix.Domain.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("Version");

                    b.Property<string>("VideoDescription");

                    b.Property<byte[]>("VideoImage");

                    b.Property<string>("VideoName");

                    b.Property<string>("VideoPrice");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Notflix.Domain.Videos.VideoGender", b =>
                {
                    b.Property<Guid>("GenderId");

                    b.Property<Guid>("VideoId");

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("Id");

                    b.Property<int>("Version");

                    b.HasKey("GenderId", "VideoId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoGender");
                });

            modelBuilder.Entity("Notflix.Domain.Payment", b =>
                {
                    b.HasOne("Notflix.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Notflix.Domain.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("Notflix.Domain.UserHistory", b =>
                {
                    b.HasOne("Notflix.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Notflix.Domain.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("Notflix.Domain.Videos.VideoGender", b =>
                {
                    b.HasOne("Notflix.Domain.Gender", "Gender")
                        .WithMany("VideoGenders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Notflix.Domain.Video", "Video")
                        .WithMany("Genders")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
