﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TodoWebAPI.Data;

namespace TodoWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180315102353_tester2")]
    partial class tester2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoWebAPI.Models.ElementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDone");

                    b.Property<int>("ListModelId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ListModelId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("TodoWebAPI.Models.ListModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("TodoWebAPI.Models.ElementModel", b =>
                {
                    b.HasOne("TodoWebAPI.Models.ListModel")
                        .WithMany("Elements")
                        .HasForeignKey("ListModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}