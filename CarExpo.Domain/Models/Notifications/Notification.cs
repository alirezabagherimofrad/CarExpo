﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Subject { get; set; }

        public string? Message { get; set; }

        public DateTime SentAt { get; set; }
    }
}
