using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Dto
{
    public class CarImageDto
    {
        public Guid CarId { get; set; }
        public IFormFile File { get; set; }
    }
}
