using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.VehicleCommand
{
    public class UploadCarImageCommand
    {
        public UploadCarImageCommand()
        {
            
        }
        public UploadCarImageCommand(Guid carid)
        {
            CarId=carid;
        }
        public Guid CarId { get; set; }

        public Guid UserId { get; set; }

        public IFormFile File { get; set; }
    }
}
