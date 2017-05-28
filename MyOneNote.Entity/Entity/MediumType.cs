using System;

namespace MyOneNote.Data.Entity
{
    public class MediumType:IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid CreateBy { get; set; }
        public string Name { get; set; }
    }
}