using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserSegmentDto
    {
        public User? Users { get; set; }
        public Segment? Segment { get; set; }
    }
}
