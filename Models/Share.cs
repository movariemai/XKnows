using System;
using System.ComponentModel.DataAnnotations;

namespace XKnows.Models
{
    public class Share
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Skill { get; set; }
        public string Level {get; set; }
        public decimal Points { get; set; }
    }
}