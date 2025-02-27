﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetworkMonitoring.Database.DBC;

#nullable disable

namespace NetworkMonitoring.Database.Migrations
{
    [DbContext(typeof(NetworkMonitoringDbContext))]
    partial class NetworkMonitoringDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemObject", b =>
                {
                    b.Property<int>("SystemObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemObjectID"));

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("SystemObjectRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemObjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemObjectID");

                    b.ToTable("Sys_SystemObject");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemUser", b =>
                {
                    b.Property<int>("SystemUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemUserID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SystemUserGroupID")
                        .HasColumnType("int");

                    b.Property<string>("SystemUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemUserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemUserID");

                    b.HasIndex("SystemUserGroupID");

                    b.ToTable("Sys_SystemUser");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemUserAccessRole", b =>
                {
                    b.Property<Guid>("SystemUserAccessRolesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SystemObjectID")
                        .HasColumnType("int");

                    b.Property<int>("SystemUserGroupID")
                        .HasColumnType("int");

                    b.HasKey("SystemUserAccessRolesID");

                    b.HasIndex("SystemObjectID");

                    b.HasIndex("SystemUserGroupID");

                    b.ToTable("Sys_SystemUserAccessRole");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemUserGroup", b =>
                {
                    b.Property<int>("SystemUserGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemUserGroupID"));

                    b.Property<string>("SystemUserGroupTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemUserGroupID");

                    b.ToTable("Sys_SystemUserGroup");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.BasicData.EquipmentLocation", b =>
                {
                    b.Property<long>("EquipmentLocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EquipmentLocationID"));

                    b.Property<string>("EquipmentLocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentLocationID");

                    b.ToTable("Bs_EquipmentLocation");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.BasicData.EquipmentType", b =>
                {
                    b.Property<long>("EquipmentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EquipmentTypeID"));

                    b.Property<string>("EquipmentTypeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentTypeID");

                    b.ToTable("Bs_EquipmentType");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Log.EquipmentLog", b =>
                {
                    b.Property<Guid>("EquipmentLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DownTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("EquipmentIPID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpTime")
                        .HasColumnType("datetime2");

                    b.HasKey("EquipmentLogID");

                    b.HasIndex("EquipmentIPID");

                    b.ToTable("Log_EquipmentILog");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.LogService.NetworkServiceLog", b =>
                {
                    b.Property<Guid>("NetworkServiceLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DownTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("NetworkServiceID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NetworkServiceLogID");

                    b.HasIndex("NetworkServiceID");

                    b.ToTable("Log_NetworkService");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Service.EquipmentIP", b =>
                {
                    b.Property<long>("EquipmentIPID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EquipmentIPID"));

                    b.Property<string>("EquipmentIPName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EquipmentLocationID")
                        .HasColumnType("bigint");

                    b.Property<long>("EquipmentTypeID")
                        .HasColumnType("bigint");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("EquipmentIPID");

                    b.HasIndex("EquipmentLocationID");

                    b.HasIndex("EquipmentTypeID");

                    b.ToTable("Srv_EquipmentIP");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Service.NetworkService", b =>
                {
                    b.Property<long>("NetworkServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NetworkServiceID"));

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("NetworkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NetworkServiceID");

                    b.ToTable("Srv_NetworkService");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemUser", b =>
                {
                    b.HasOne("NetworkMonitoring.Domain.Account.SystemUserGroup", "SystemUserGroup")
                        .WithMany()
                        .HasForeignKey("SystemUserGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUserGroup");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Account.SystemUserAccessRole", b =>
                {
                    b.HasOne("NetworkMonitoring.Domain.Account.SystemObject", "SystemObject")
                        .WithMany()
                        .HasForeignKey("SystemObjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetworkMonitoring.Domain.Account.SystemUserGroup", "SystemUserGroup")
                        .WithMany()
                        .HasForeignKey("SystemUserGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemObject");

                    b.Navigation("SystemUserGroup");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Log.EquipmentLog", b =>
                {
                    b.HasOne("NetworkMonitoring.Domain.Service.EquipmentIP", "EquipmentIP")
                        .WithMany()
                        .HasForeignKey("EquipmentIPID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentIP");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.LogService.NetworkServiceLog", b =>
                {
                    b.HasOne("NetworkMonitoring.Domain.Service.NetworkService", "NetworkService")
                        .WithMany()
                        .HasForeignKey("NetworkServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetworkService");
                });

            modelBuilder.Entity("NetworkMonitoring.Domain.Service.EquipmentIP", b =>
                {
                    b.HasOne("NetworkMonitoring.Domain.BasicData.EquipmentLocation", "EquipmentLocation")
                        .WithMany()
                        .HasForeignKey("EquipmentLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetworkMonitoring.Domain.BasicData.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentLocation");

                    b.Navigation("EquipmentType");
                });
#pragma warning restore 612, 618
        }
    }
}
