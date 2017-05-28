using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.EntityMap;


namespace MyOneNote.EF
{
    public class MyOneNoteContext : IdentityDbContext<ApplicationUser, IdentityRole,string>
    {
        public MyOneNoteContext(DbContextOptions<MyOneNoteContext> options) :base(options)
        {
             
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Medium> Mediums { get; set; }
        public DbSet<MediumType> MediumTypes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ContentReviews> ContentReviews { get; set; }
        public DbSet<ContentRatings> ContentRatings { get; set; }
        public DbSet<ContentTags> ContentTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CategoryMap(modelBuilder.Entity<Category>());
            new LinkMap(modelBuilder.Entity<Link>());
            new MediumMap(modelBuilder.Entity<Medium>());
            new MediumTypeMap(modelBuilder.Entity<MediumType>());
            new NoteMap(modelBuilder.Entity<Note>());
            new ProjectMap(modelBuilder.Entity<Project>());
            new RatingMap(modelBuilder.Entity<Rating>());
            new ReviewMap(modelBuilder.Entity<Review>());
            new ScoreMap(modelBuilder.Entity<Score>());
            new TagMap(modelBuilder.Entity<Tag>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());
            new ContentReviewsMap(modelBuilder.Entity<ContentReviews>());
            new ContentRatingsMap(modelBuilder.Entity<ContentRatings>());
            new ContentTagsMap(modelBuilder.Entity<ContentTags>());


        }
    }
}