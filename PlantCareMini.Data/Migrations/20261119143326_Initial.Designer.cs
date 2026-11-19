using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantCareMini.Data;

#nullable disable

namespace PlantCareMini.Data.Migrations
{
    [DbContext(typeof(PlantCareDbContext))]
    [Migration("20261119143326_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlantCareMini.Data.Entities.GrowingLocation", b =>
                {
                    b.Property<int>("GrowingLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrowingLocationId"));

                    b.Property<int>("LocationType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GrowingLocationId");

                    b.ToTable("GrowingLocations");
                });

            modelBuilder.Entity("PlantCareMini.Data.Entities.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("GrowingLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlantTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WateringIntervalDays")
                        .HasColumnType("int");

                    b.HasKey("PlantId");

                    b.HasIndex("GrowingLocationId");

                    b.HasIndex("PlantTypeId");

                    b.ToTable("Plants", null, t =>
                        {
                            t.HasCheckConstraint("CK_Plants_WateringIntervalDays", "[WateringIntervalDays] > 0");
                        });
                });

            modelBuilder.Entity("PlantCareMini.Data.Entities.PlantType", b =>
                {
                    b.Property<int>("PlantTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantTypeId"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("LightRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PlantTypeId");

                    b.ToTable("PlantTypes");
                });

            modelBuilder.Entity("PlantCareMini.Data.Entities.Plant", b =>
                {
                    b.HasOne("PlantCareMini.Data.Entities.GrowingLocation", "GrowingLocation")
                        .WithMany("Plants")
                        .HasForeignKey("GrowingLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PlantCareMini.Data.Entities.PlantType", "PlantType")
                        .WithMany("Plants")
                        .HasForeignKey("PlantTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrowingLocation");

                    b.Navigation("PlantType");
                });

            modelBuilder.Entity("PlantCareMini.Data.Entities.GrowingLocation", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("PlantCareMini.Data.Entities.PlantType", b =>
                {
                    b.Navigation("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
