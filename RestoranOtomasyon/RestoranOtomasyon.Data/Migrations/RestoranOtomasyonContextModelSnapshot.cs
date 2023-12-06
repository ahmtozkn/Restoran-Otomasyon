﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestoranOtomasyon.Data.Context;

#nullable disable

namespace RestoranOtomasyon.Data.Migrations
{
    [DbContext(typeof(RestoranOtomasyonContext))]
    partial class RestoranOtomasyonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestoranId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestoranId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.FoodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestoranId")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RestoranId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.OrderDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("OrderEntities");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.RestoranEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestroanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restorans");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.TableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsActivated")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestoranId")
                        .HasColumnType("int");

                    b.Property<string>("TableNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestoranId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.WorkerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeStatus")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestoranId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestoranId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.CategoryEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.RestoranEntity", "Restoran")
                        .WithMany("Categories")
                        .HasForeignKey("RestoranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.FoodEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.CategoryEntity", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestoranOtomasyon.Data.Entities.RestoranEntity", "Restoran")
                        .WithMany("Foods")
                        .HasForeignKey("RestoranId")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.OrderDetailEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.FoodEntity", "Food")
                        .WithMany("OrderDetails")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestoranOtomasyon.Data.Entities.OrderEntity", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.OrderEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.TableEntity", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.TableEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.RestoranEntity", "Restoran")
                        .WithMany("Tables")
                        .HasForeignKey("RestoranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.WorkerEntity", b =>
                {
                    b.HasOne("RestoranOtomasyon.Data.Entities.RestoranEntity", "Restoran")
                        .WithMany("Workers")
                        .HasForeignKey("RestoranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.FoodEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.RestoranEntity", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Foods");

                    b.Navigation("Tables");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("RestoranOtomasyon.Data.Entities.TableEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}