﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflowCopy.Entities;

#nullable disable

namespace StackOverflowCopy.Migrations
{
    [DbContext(typeof(StackOverflowContext))]
    [Migration("20220519082557_addedTableAnswear")]
    partial class addedTableAnswear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuestionTag", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId1")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "TagsId1");

                    b.HasIndex("TagsId1");

                    b.ToTable("QuestionTag");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Answear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnswearToQuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("BestAnswear")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PointsRankOfAnswear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswearToQuestionId");

                    b.ToTable("Answears");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnswearId")
                        .HasColumnType("int");

                    b.Property<bool>("CommentAnswear")
                        .HasColumnType("bit");

                    b.Property<bool>("CommentQuestion")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswearId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("QuestionTag", b =>
                {
                    b.HasOne("StackOverflowCopy.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowCopy.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Answear", b =>
                {
                    b.HasOne("StackOverflowCopy.Entities.Question", "AnswearToQuestion")
                        .WithMany("Answears")
                        .HasForeignKey("AnswearToQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswearToQuestion");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Comment", b =>
                {
                    b.HasOne("StackOverflowCopy.Entities.Answear", null)
                        .WithMany("CommentsAnswear")
                        .HasForeignKey("AnswearId");

                    b.HasOne("StackOverflowCopy.Entities.Question", "Question")
                        .WithMany("Comments")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Answear", b =>
                {
                    b.Navigation("CommentsAnswear");
                });

            modelBuilder.Entity("StackOverflowCopy.Entities.Question", b =>
                {
                    b.Navigation("Answears");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
