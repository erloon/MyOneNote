using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyOneNote.EF;

namespace MyOneNote.EF.Migrations
{
    [DbContext(typeof(MyOneNoteContext))]
    partial class MyOneNoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyOneNote.API.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CreateBy");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentRatings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<Guid>("RatingId");

                    b.Property<Guid?>("ScoreId");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.HasIndex("ScoreId");

                    b.ToTable("ContentRatings");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentReviews", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<Guid>("ReviewId");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("ContentReviews");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentTags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<Guid>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("ContentTags");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModyficationDate");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(250);

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreateBy");

                    b.HasIndex("ProjectId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Medium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid?>("ContentTypeId");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModyficationDate");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(250);

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ContentTypeId");

                    b.HasIndex("CreateBy");

                    b.HasIndex("ProjectId");

                    b.ToTable("Mediums");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.MediumType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CreateBy");

                    b.ToTable("MediumTypes");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModyficationDate");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreateBy");

                    b.HasIndex("ProjectId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModyficationDate");

                    b.Property<Guid>("ScoreId");

                    b.HasKey("Id");

                    b.HasIndex("CreateBy");

                    b.HasIndex("ScoreId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModyficationDate");

                    b.HasKey("Id");

                    b.HasIndex("CreateBy");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Rate")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyOneNote.API.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyOneNote.API.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.API.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Category", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Categories")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentRatings", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Rating", "Rating")
                        .WithMany("ConentRatings")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.Score")
                        .WithMany("ContentRatings")
                        .HasForeignKey("ScoreId");
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentReviews", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Review", "Review")
                        .WithMany("ContentReviewses")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.ContentTags", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Tag", "Tag")
                        .WithMany("ContentTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Link", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Category", "Category")
                        .WithMany("Links")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Links")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.Project", "Project")
                        .WithMany("Links")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Medium", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Category", "Category")
                        .WithMany("Mediums")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.MediumType", "ContentType")
                        .WithMany()
                        .HasForeignKey("ContentTypeId");

                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Mediums")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.Project", "Project")
                        .WithMany("Mediums")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.MediumType", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("MediumTypes")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Note", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.Category", "Category")
                        .WithMany("Notes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Notes")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.Project", "Project")
                        .WithMany("Notes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Project", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Projects")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Rating", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Ratings")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyOneNote.Data.Entity.Score", "Score")
                        .WithMany("Ratings")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Review", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Reviews")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyOneNote.Data.Entity.Tag", b =>
                {
                    b.HasOne("MyOneNote.Data.Entity.UserProfile", "UserProfile")
                        .WithMany("Tags")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
