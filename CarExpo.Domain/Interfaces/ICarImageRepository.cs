using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces
{
    public interface ICarImageRepository : IGenericRepository<CarImage>
    {

        
        Task<CarImage?> DownloadCarImageAsync(Guid Id);

        Task<CarImage?> UploadImageAsync(Guid Id);
    }
}
