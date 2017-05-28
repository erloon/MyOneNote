using System;

namespace MyOneNote.Data.Entity
{
    public class Link:Aggregate
    {
        public string ShortDescription { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Content { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public string Url { get; set; }

    }
}