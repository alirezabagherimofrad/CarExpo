﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Dto.InvoiceDto
{
    public class InvoiceCommandDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
