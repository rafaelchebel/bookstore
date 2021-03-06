﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bookstore.Repository.Data;

namespace Bookstore.Repository.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20180823001312_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6");

            modelBuilder.Entity("Bookstore.Model.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("PublishingHouse");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.Property<string>("YearOfPublishing");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });
        }
    }
}
