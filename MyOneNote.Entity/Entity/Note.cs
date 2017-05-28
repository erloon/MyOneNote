using System;

namespace MyOneNote.Data.Entity
{
    public class Note:Aggregate,IEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public string Content { get; set; }
    }
}