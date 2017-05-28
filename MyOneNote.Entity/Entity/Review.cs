using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class Review:Aggregate   
    {
        public string Content { get; set; }
        public virtual ICollection<ContentReviews> ContentReviewses { get; set; }

    }
}