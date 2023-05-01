﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(OrganizationContext))]
    partial class OrganizationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.DomainEntities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Department");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Engineering",
                            Name = "Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Finance",
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Marketing",
                            Name = "Marketing"
                        });
                });

            modelBuilder.Entity("Infrastructure.DomainEntities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Employee");

                    b.HasIndex("FunctionId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FunctionId = 1,
                            Name = "Taj"
                        },
                        new
                        {
                            Id = 2,
                            FunctionId = 1,
                            Name = "Rajneesh Kumar"
                        },
                        new
                        {
                            Id = 3,
                            FunctionId = 1,
                            Name = "Sudhanshu Jain"
                        });
                });

            modelBuilder.Entity("Infrastructure.DomainEntities.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Function");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Function");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Description = "Associate Software Engineer",
                            Name = "Associate Software Engineer"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Description = "Associate Software Engineer",
                            Name = "Software Engineer"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 1,
                            Description = "Associate Software Engineer",
                            Name = "Senior Software Engineer"
                        });
                });

            modelBuilder.Entity("Infrastructure.DomainEntities.Employee", b =>
                {
                    b.HasOne("Infrastructure.DomainEntities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");
                });

            modelBuilder.Entity("Infrastructure.DomainEntities.Function", b =>
                {
                    b.HasOne("Infrastructure.DomainEntities.Department", "Department")
                        .WithMany("Functions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Infrastructure.DomainEntities.Department", b =>
                {
                    b.Navigation("Functions");
                });
#pragma warning restore 612, 618
        }
    }
}