﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.NET.Application.Broker
{
    public class MessageDto
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool IsSuccess { get; set; }

        public int UserId { get; set; }
    }
}