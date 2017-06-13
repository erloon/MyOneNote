using System;
using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class UserProfile:IEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Organization { get; set; }
        public string Specialization { get; set; }



        public virtual ICollection<MediumType> MediumTypes { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Medium> Mediums { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public UserProfile()
        {
            
        }
        public UserProfile(string userId)
        {
            Id=Guid.Parse("e30f04e3-30f4-4a83-9da1-1556b99c0a13");
            UserId = userId;
        }
    }
}