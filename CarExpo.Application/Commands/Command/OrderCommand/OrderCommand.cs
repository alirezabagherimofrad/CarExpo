using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.OrserCommand
{
    public class OrderCommand
    {
        public Guid CarId { get; set; }

        public Guid UserId { get; set; }
    }
}
