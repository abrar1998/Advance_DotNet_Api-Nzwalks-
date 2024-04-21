﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZZwalks.DataContext;

#nullable disable

namespace NZZwalks.Migrations
{
    [DbContext(typeof(AccountContext))]
    partial class AccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZZwalks.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficultes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e3b6568a-1119-4e30-bc8c-f7a4913818ec"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("db804d2d-4ee6-4efc-947c-a8d0897c81f6"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("75636fd6-b9ef-4733-b825-c86b113ff0f9"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZZwalks.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescritpion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NZZwalks.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImgUlr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a26d1ff-e379-4df3-9e01-1c4180fcdc39"),
                            Code = "BOP",
                            Name = "Bay of Plenty",
                            RegionImgUlr = "null"
                        },
                        new
                        {
                            Id = new Guid("8e61003c-75a9-41dc-a8fd-fe63e87ebef8"),
                            Code = "AKL",
                            Name = "AuckLand",
                            RegionImgUlr = "https://www.bing.com/images/search?view=detailV2&ccid=UkG89vab&id=371078079B0C47E89D79B33CEAB95F88E61D1DB6&thid=OIP.UkG89vab4fcyUBAA5VjC6gHaFP&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.5241bcf6f69be1f732501000e558c2ea%3frik%3dth0d5ohfueo8sw%26riu%3dhttp%253a%252f%252fwallpapercave.com%252fwp%252fsoSaTJM.jpg%26ehk%3dnUl6MV1yd74%252fP%252fWBLP%252b5aM%252fDbbp7HkpX1PCLIEK%252feVo%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1700&expw=2400&q=nature+pics&simid=608044958947812527&FORM=IRPRST&ck=BA5A9B2E1D264AF298F494ADAEAB30BF&selectedIndex=0&itb=0&idpp=overlayview&ajaxhist=0&ajaxserp=0"
                        },
                        new
                        {
                            Id = new Guid("5581f6b5-5324-496c-ac24-eea19275ad4d"),
                            Code = "NL",
                            Name = "North Land",
                            RegionImgUlr = "null"
                        });
                });

            modelBuilder.Entity("NZZwalks.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInkm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZZwalks.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZZwalks.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZZwalks.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
