using System;

namespace CQS.DB.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Operation { get; set; }
        public string Data { get; set; }
    }
}
