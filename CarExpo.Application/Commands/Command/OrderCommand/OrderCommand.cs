using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.OrserCommand
{
    public class OrderCommand
    {
        public Guid CarId { get; private set; }

        public Guid UserId { get; private set; }

        public OrderCommand(Guid carid, Guid userid)
        {
            CarId = carid;
            UserId = userid;
        }
    }
}
