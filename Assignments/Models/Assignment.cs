using System;

namespace Assignments.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UrgencyLevel { get; set; }
        public DateTime DueDate { get; set; }
    }
}
