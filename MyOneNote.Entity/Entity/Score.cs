using System;
using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class Score:IEntity
    {
        public Guid Id { get; set; }
        public byte Rate { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public ICollection<ContentRatings> ContentRatings { get; set; }
    }
}