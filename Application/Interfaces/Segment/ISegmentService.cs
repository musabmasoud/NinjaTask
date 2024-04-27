﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISegmentService
    {
        Task<Segment>Create(Segment segment);
        Task<List<Segment>> GetAllSegment();
    }
}
