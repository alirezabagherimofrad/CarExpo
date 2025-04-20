using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Dto.IanalyticsDto
{
    public class CarListDto
    {
        public Guid Id { get; set; }
        //public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
