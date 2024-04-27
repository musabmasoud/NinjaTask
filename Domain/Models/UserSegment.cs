using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserSegment
    {
        public Guid Id { get; set; }    
        public Guid UserId { get; set; }
        public Guid SegmentId { get; set; }
        public Users? Users { get; set; }
        public Segment? Segment { get; set; }
    }
}
