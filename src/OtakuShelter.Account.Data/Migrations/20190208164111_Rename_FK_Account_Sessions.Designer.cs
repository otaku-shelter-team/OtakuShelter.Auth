﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OtakuShelter.Account;

namespace OtakuShelter.Account.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20190208164111_Rename_FK_Account_Sessions")]
    partial class Rename_FK_Account_Sessions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OtakuShelter.Account.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("passwordhash")
                        .HasMaxLength(500);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("OtakuShelter.Account.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnName("accountid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnName("datetime");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnName("ipaddress")
                        .HasMaxLength(20);

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnName("refresh")
                        .HasMaxLength(500);

                    b.Property<string>("UserAgent")
                        .HasColumnName("useragent")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("tokens");
                });

            modelBuilder.Entity("OtakuShelter.Account.Token", b =>
                {
                    b.HasOne("OtakuShelter.Account.Account", "Account")
                        .WithMany("Tokens")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_account_tokens")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}