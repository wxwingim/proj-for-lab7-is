// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServerApp;

namespace ServerApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230108145225_AddedData")]
    partial class AddedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataBaseEntities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("inventory");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("DataBaseEntities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("integer");

                    b.Property<int>("InventoryId")
                        .HasColumnName("inventory_id")
                        .HasColumnType("integer");

                    b.Property<string>("InventoryNumber")
                        .HasColumnName("inventory_number")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2,
                            InventoryId = 1,
                            InventoryNumber = "0001",
                            Name = "Name1"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 45,
                            InventoryId = 1,
                            InventoryNumber = "0002",
                            Name = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1,
                            InventoryId = 1,
                            InventoryNumber = "0003",
                            Name = "Name3"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 2,
                            InventoryId = 2,
                            InventoryNumber = "0001",
                            Name = "Name1"
                        });
                });

            modelBuilder.Entity("DataBaseEntities.Item", b =>
                {
                    b.HasOne("DataBaseEntities.Inventory", "Inventory")
                        .WithMany("Items")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
