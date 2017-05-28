using System;

namespace MyOneNote.Data.Entity
{
    public class Aggregate:IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModyficationDate { get; set; }
        public Guid CreateBy { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}