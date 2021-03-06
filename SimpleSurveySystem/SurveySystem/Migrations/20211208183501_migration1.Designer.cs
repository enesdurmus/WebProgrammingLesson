// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveySystem.Data;

namespace SurveySystem.Migrations
{
    [DbContext(typeof(SurveyContext))]
    [Migration("20211208183501_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveySurveyQuestion", b =>
                {
                    b.Property<int>("SurveyQuestionsID")
                        .HasColumnType("int");

                    b.Property<int>("SurveysID")
                        .HasColumnType("int");

                    b.HasKey("SurveyQuestionsID", "SurveysID");

                    b.HasIndex("SurveysID");

                    b.ToTable("SurveySurveyQuestion");
                });

            modelBuilder.Entity("SurveySurveyResponse", b =>
                {
                    b.Property<int>("SurveyResponsesID")
                        .HasColumnType("int");

                    b.Property<int>("SurveysID")
                        .HasColumnType("int");

                    b.HasKey("SurveyResponsesID", "SurveysID");

                    b.HasIndex("SurveysID");

                    b.ToTable("SurveySurveyResponse");
                });

            modelBuilder.Entity("SurveySystem.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SurveyQuestionID")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyResponseID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SurveyQuestionID");

                    b.HasIndex("SurveyResponseID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SurveySystem.Models.Survey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("SurveySystem.Models.SurveyQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SurveyQuestion");
                });

            modelBuilder.Entity("SurveySystem.Models.SurveyResponse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilledBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SurveyResponse");
                });

            modelBuilder.Entity("SurveySurveyQuestion", b =>
                {
                    b.HasOne("SurveySystem.Models.SurveyQuestion", null)
                        .WithMany()
                        .HasForeignKey("SurveyQuestionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveySystem.Models.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveysID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SurveySurveyResponse", b =>
                {
                    b.HasOne("SurveySystem.Models.SurveyResponse", null)
                        .WithMany()
                        .HasForeignKey("SurveyResponsesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveySystem.Models.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveysID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SurveySystem.Models.Question", b =>
                {
                    b.HasOne("SurveySystem.Models.SurveyQuestion", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyQuestionID");

                    b.HasOne("SurveySystem.Models.SurveyResponse", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyResponseID");
                });

            modelBuilder.Entity("SurveySystem.Models.Survey", b =>
                {
                    b.HasOne("SurveySystem.Models.Question", null)
                        .WithMany("Surveys")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("SurveySystem.Models.Question", b =>
                {
                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("SurveySystem.Models.SurveyQuestion", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("SurveySystem.Models.SurveyResponse", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
