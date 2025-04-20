using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.CarRepositories
{
    public interface ICarImageRepository : IGenericRepository<CarImage>
    {


        Task<CarImage?> DownloadCarImageAsync(Guid Id);

        Task<CarImage?> UploadImageAsync(Guid Id);
    }
}
