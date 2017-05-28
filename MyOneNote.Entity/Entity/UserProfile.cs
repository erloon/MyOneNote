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
    }
}