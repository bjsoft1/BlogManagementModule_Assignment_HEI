﻿// <auto-generated />
using System;
using BlogManagementModule.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogManagementModule.Services.Migrations
{
    [DbContext(typeof(DatabaseConfiguration))]
    partial class DatabaseConfigurationModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BlogCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("BlogDescription")
                        .HasColumnType("text");

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BlogStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("CreationTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleteTime")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAllowPublicComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    b.HasIndex("BlogCategoryId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeletorId");

                    b.HasIndex("LastModifiedId");

                    b.ToTable("blogAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello1",
                            BlogName = "Title1",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 2L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello2",
                            BlogName = "Title2",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 3L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello3",
                            BlogName = "Title3",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 4L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello4",
                            BlogName = "Title4",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 5L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello5",
                            BlogName = "Title5",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 6L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello6",
                            BlogName = "Title6",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 7L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello7",
                            BlogName = "Title7",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        },
                        new
                        {
                            Id = 8L,
                            BlogCategoryId = 1,
                            BlogDescription = "Hello8",
                            BlogName = "Title8",
                            BlogStatus = 0,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            CreatorId = 1L,
                            IsAllowPublicComment = true,
                            IsDelete = false,
                            IsPublic = true,
                            ViewCount = 0L
                        });
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    b.ToTable("blogCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "IT",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Bank",
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "School",
                            IsActive = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Collage",
                            IsActive = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Account",
                            IsActive = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Coding",
                            IsActive = true
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "GameDevelopment",
                            IsActive = true
                        },
                        new
                        {
                            Id = 8,
                            CategoryName = "UnrealEngine",
                            IsActive = true
                        },
                        new
                        {
                            Id = 9,
                            CategoryName = "C++",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogComments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeleteRemarks")
                        .HasColumnType("text");

                    b.Property<long?>("DeleteTime")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeletorId");

                    b.HasIndex("LastModifiedId");

                    b.ToTable("blogComments", (string)null);
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogFileInformation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BlogAccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreationTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleteTime")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletorId")
                        .HasColumnType("bigint");

                    b.Property<string>("FileLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BlogAccountId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeletorId");

                    b.HasIndex("LastModifiedId");

                    b.ToTable("blogFileInformations");
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogViewHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreationTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPublicUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatorId");

                    b.ToTable("blogViewHistory", (string)null);
                });

            modelBuilder.Entity("BlogManagementModule.Models.UserAccounts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DeletorId")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PermanentAddress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Roles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(2);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    b.HasIndex("DeletorId");

                    b.HasIndex("LastModifiedId");

                    b.ToTable("userAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bijay.adhikari.27648@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9865413772",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 1,
                            Username = "Bijay_Admin"
                        },
                        new
                        {
                            Id = 2L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bjsoft1@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9827876333",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 2,
                            Username = "Bijay_User"
                        },
                        new
                        {
                            Id = 3L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bijay.adhikari1@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9800000000",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 2,
                            Username = "Bijay_User1"
                        },
                        new
                        {
                            Id = 4L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bijay.adhikari2@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9800000001",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 2,
                            Username = "Bijay_User2"
                        },
                        new
                        {
                            Id = 5L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bijay.adhikari3@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9800000002",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 2,
                            Username = "Bijay_User3"
                        },
                        new
                        {
                            Id = 6L,
                            CreationTime = new DateTime(2023, 5, 15, 15, 39, 38, 895, DateTimeKind.Unspecified).AddTicks(1135),
                            EmailAddress = "bijay.adhikari4@gmail.com",
                            IsDelete = false,
                            MobileNumber = "+977-9800000003",
                            Password = "a2V84dW0kxwifkSgpGgF6QFmKF3ivFNgjB+sPV3pvi0=",
                            PermanentAddress = "Lalbandi,Sarlahi",
                            Roles = 2,
                            Username = "Bijay_User4"
                        });
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogAccount", b =>
                {
                    b.HasOne("BlogManagementModule.Models.BlogEntities.BlogCategories", "BlogCategory")
                        .WithMany()
                        .HasForeignKey("BlogCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Deletor")
                        .WithMany()
                        .HasForeignKey("DeletorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "LastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BlogCategory");

                    b.Navigation("Creator");

                    b.Navigation("Deletor");

                    b.Navigation("LastModified");
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogComments", b =>
                {
                    b.HasOne("BlogManagementModule.Models.BlogEntities.BlogAccount", "BlogAccount")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Deletor")
                        .WithMany()
                        .HasForeignKey("DeletorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "LastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BlogAccount");

                    b.Navigation("Creator");

                    b.Navigation("Deletor");

                    b.Navigation("LastModified");
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogFileInformation", b =>
                {
                    b.HasOne("BlogManagementModule.Models.BlogEntities.BlogAccount", "BlogAccount")
                        .WithMany()
                        .HasForeignKey("BlogAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Deletor")
                        .WithMany()
                        .HasForeignKey("DeletorId");

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "LastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedId");

                    b.Navigation("BlogAccount");

                    b.Navigation("Creator");

                    b.Navigation("Deletor");

                    b.Navigation("LastModified");
                });

            modelBuilder.Entity("BlogManagementModule.Models.BlogEntities.BlogViewHistory", b =>
                {
                    b.HasOne("BlogManagementModule.Models.BlogEntities.BlogAccount", "BlogAccount")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BlogAccount");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BlogManagementModule.Models.UserAccounts", b =>
                {
                    b.HasOne("BlogManagementModule.Models.UserAccounts", "Deletor")
                        .WithMany()
                        .HasForeignKey("DeletorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlogManagementModule.Models.UserAccounts", "LastModified")
                        .WithMany()
                        .HasForeignKey("LastModifiedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Deletor");

                    b.Navigation("LastModified");
                });
#pragma warning restore 612, 618
        }
    }
}