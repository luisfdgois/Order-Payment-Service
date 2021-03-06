// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220518002539_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("ProductValue")
                        .HasColumnType("numeric(8,2)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.HasBaseType("Domain.Entities.Payment");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("NumberOfInstallment")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValuePerInstallment")
                        .HasColumnType("numeric(8,2)");

                    b.ToTable("CreditCard", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Domain.Entities.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Domain.Entities.Payment", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.CreditCard", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
