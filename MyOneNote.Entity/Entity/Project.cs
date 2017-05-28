using System;
using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class Project:IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid UserProfileId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Medium> Mediums { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}