using System;
using System.Collections.Generic;

namespace MyOneNote.Data.Entity
{
    public class ContentReviews:IEntity
    {
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Guid ReviewId { get; set; }
        public Review Review { get; set; }
    }
}