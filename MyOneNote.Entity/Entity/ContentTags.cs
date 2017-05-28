using System;

namespace MyOneNote.Data.Entity
{
    public class ContentTags:IEntity
    {
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }

    }
}