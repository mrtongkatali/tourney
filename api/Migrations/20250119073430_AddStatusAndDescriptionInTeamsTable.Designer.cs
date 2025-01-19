﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tourney.api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250119073430_AddStatusAndDescriptionInTeamsTable")]
    partial class AddStatusAndDescriptionInTeamsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("team_id_sequence");

            modelBuilder.HasSequence<int>("tournament_id_sequence");

            modelBuilder.HasSequence<int>("tournament_stage_id_sequence");

            modelBuilder.HasSequence<int>("user_profile_id_sequence");

            modelBuilder.HasSequence<int>("users_id_sequence");

            modelBuilder.Entity("tourney.api.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('\"team_id_sequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("tournamentId")
                        .HasColumnType("integer")
                        .HasColumnName("tournament_id");

                    b.HasKey("Id");

                    b.HasIndex("tournamentId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("tourney.api.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('\"tournament_id_sequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("ParticipantSize")
                        .HasColumnType("int")
                        .HasColumnName("participant_size");

                    b.Property<decimal>("PrizePool")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("prize_pool");

                    b.Property<string>("PrizePoolCurrency")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasColumnName("prize_pool_currency");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("TournamentType")
                        .HasColumnType("integer")
                        .HasColumnName("tournament_type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tournaments");
                });

            modelBuilder.Entity("tourney.api.Models.TournamentStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('\"tournament_stage_id_sequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<int>("StageFormat")
                        .HasColumnType("integer")
                        .HasColumnName("stage_format");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("stage_name");

                    b.Property<int>("StageOrder")
                        .HasColumnType("int")
                        .HasColumnName("stage_order");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer")
                        .HasColumnName("tournament_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("tournament_stages");
                });

            modelBuilder.Entity("tourney.api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('\"users_id_sequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("tourney.api.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"user_profile_id_sequence\"')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("user_profiles");
                });

            modelBuilder.Entity("tourney.api.Models.Team", b =>
                {
                    b.HasOne("tourney.api.Models.Tournament", "Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("tournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("tourney.api.Models.Tournament", b =>
                {
                    b.HasOne("tourney.api.Models.User", "User")
                        .WithMany("Tournaments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tourney.api.Models.TournamentStage", b =>
                {
                    b.HasOne("tourney.api.Models.Tournament", "Tournament")
                        .WithMany("Stages")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("tourney.api.Models.UserProfile", b =>
                {
                    b.HasOne("tourney.api.Models.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("tourney.api.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tourney.api.Models.Tournament", b =>
                {
                    b.Navigation("Stages");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("tourney.api.Models.User", b =>
                {
                    b.Navigation("Tournaments");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
