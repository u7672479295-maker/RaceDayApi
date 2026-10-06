using RaceDay.Models;
using System.ComponentModel.DataAnnotations;

namespace RaceDayApi.Models
{
    public class Enrolment
    {
        public int EnrolmentId { get; set; }
        public int ParticipantUserId { get; set; }
        public int EventId { get; set; }
        public int CategoryId { get; set; }

        public DateTime EnrolmentDate { get; set; }
        = DateTime.UtcNow;


        public User? ParticipantUser { get; }
        public Event? Event { get; set; }
        public Category? Category { get; set; } 
        public Result? Result { get; set; }
    
    }
}
