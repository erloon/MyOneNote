using System;

namespace MyOneNote.Data.Entity
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}