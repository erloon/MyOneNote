using System;

namespace MyOneNote.Data.Entity
{
    public class ContentRatings:IEntity
    {
        public Guid Id { get; set; }

        public Guid ContentId { get; set; }
        public Rating Rating { get; set; }
        public Guid RatingId { get; set; }

    }
}