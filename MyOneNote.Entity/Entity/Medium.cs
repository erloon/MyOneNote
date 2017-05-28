using System;

namespace MyOneNote.Data.Entity
{
    public class Medium:Aggregate
    {
        public string ShortDescription { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public MediumType ContentType { get; set; }
    }
}