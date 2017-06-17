using System;

namespace MyOneNote.ViewModels.Note
{
    public class ListNoteVM
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        
        public string Category { get; set; }
        public Guid CategoryId { get; set; }

        public decimal Rating
        {
            get
            {
                Random random = new Random();
                return random.Next(0, 100);
            }
        }

    }
}