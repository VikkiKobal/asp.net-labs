using ASPNetExapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata; 

#nullable disable

namespace ASPNetExapp.Migrations
{
    [DbContext(typeof(CarDbContext))]
    [Migration("20250218200319_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarModels.Car", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Number")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Year")
                    .HasColumnType("int");

                b.Property<string>("Brand")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Color")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Condition")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("OwnerLastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Address")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Cars");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Number = "AA1234BB",
                        Year = 2015,
                        Brand = "Toyota",
                        Color = "Red",
                        Condition = "Good",
                        OwnerLastName = "Smith",
                        Address = "123 Main St"
                    },
                    new
                    {
                        Id = 2,
                        Number = "BB5678CC",
                        Year = 2020,
                        Brand = "Honda",
                        Color = "Blue",
                        Condition = "Excellent",
                        OwnerLastName = "Johnson",
                        Address = "456 Oak Ave"
                    },
                    new
                    {
                        Id = 3,
                        Number = "CC9101DD",
                        Year = 2018,
                        Brand = "Ford",
                        Color = "Black",
                        Condition = "Fair",
                        OwnerLastName = "Brown",
                        Address = "789 Pine Rd"
                    },
                    new
                    {
                        Id = 4,
                        Number = "DD1122EE",
                        Year = 2022,
                        Brand = "BMW",
                        Color = "White",
                        Condition = "New",
                        OwnerLastName = "Davis",
                        Address = "101 Elm St"
                    });
            });
#pragma warning restore 612, 618
        }
    }
}
