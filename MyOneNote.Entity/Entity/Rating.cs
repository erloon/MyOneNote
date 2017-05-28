using System;
using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class Rating:Aggregate
    {
        public Score Score { get; set; }
        public Guid ScoreId { get; set; }

        public virtual ICollection<ContentRatings> ConentRatings { get; set; }
    }
}