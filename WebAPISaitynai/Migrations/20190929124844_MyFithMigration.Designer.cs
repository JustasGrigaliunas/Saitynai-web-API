﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPISaitynai.Models;

namespace WebAPISaitynai.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20190929124844_MyFithMigration")]
    partial class MyFithMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPISaitynai.Models.ClientItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyCode");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<bool>("IsVATPayer");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("ClientItems");
                });

            modelBuilder.Entity("WebAPISaitynai.Models.GoodsItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Description");

                    b.Property<double>("GrossPrice");

                    b.Property<int>("InvoiceId");

                    b.Property<long?>("InvoiceItemId");

                    b.Property<double>("NetPrice");

                    b.Property<int>("VAT");

                    b.Property<double>("VATAmount");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceItemId");

                    b.ToTable("GoodsItems");
                });

            modelBuilder.Entity("WebAPISaitynai.Models.InvoiceItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<long?>("ClientItemId");

                    b.Property<double>("GrossPrice");

                    b.Property<string>("InvoiceNumber");

                    b.Property<bool>("IsPayed");

                    b.Property<double>("NetPrice");

                    b.Property<int>("VAT");

                    b.Property<double>("VATAmount");

                    b.HasKey("Id");

                    b.HasIndex("ClientItemId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("WebAPISaitynai.Models.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("WebAPISaitynai.Models.GoodsItem", b =>
                {
                    b.HasOne("WebAPISaitynai.Models.InvoiceItem", "InvoiceItem")
                        .WithMany("GoodsItems")
                        .HasForeignKey("InvoiceItemId");
                });

            modelBuilder.Entity("WebAPISaitynai.Models.InvoiceItem", b =>
                {
                    b.HasOne("WebAPISaitynai.Models.ClientItem", "ClientItem")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ClientItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
