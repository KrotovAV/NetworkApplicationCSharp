﻿// <auto-generated />
using System;
using ChatDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatDb.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20231231065151_InitialMigration2")]
    partial class InitialMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChatCommon.Models.Message", b =>
                {
                    b.Property<int?>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("messageData");

                    b.Property<bool>("IsSent")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_sent");

                    b.Property<string>("Text")
                        .HasColumnType("longtext")
                        .HasColumnName("messageText");

                    b.Property<int?>("UserFromId")
                        .HasColumnType("int");

                    b.Property<int?>("UserToId")
                        .HasColumnType("int");

                    b.HasKey("MessageId")
                        .HasName("messagePk");

                    b.HasIndex("UserFromId");

                    b.HasIndex("UserToId");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("ChatCommon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("FullName");

                    b.HasKey("Id")
                        .HasName("userPk");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ChatCommon.Models.Message", b =>
                {
                    b.HasOne("ChatCommon.Models.User", "UserFrom")
                        .WithMany("MessagesFrom")
                        .HasForeignKey("UserFromId")
                        .HasConstraintName("messageFromUserFk");

                    b.HasOne("ChatCommon.Models.User", "UserTo")
                        .WithMany("MessagesTo")
                        .HasForeignKey("UserToId")
                        .HasConstraintName("messageToUserFk");

                    b.Navigation("UserFrom");

                    b.Navigation("UserTo");
                });

            modelBuilder.Entity("ChatCommon.Models.User", b =>
                {
                    b.Navigation("MessagesFrom");

                    b.Navigation("MessagesTo");
                });
#pragma warning restore 612, 618
        }
    }
}
