using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Vehicles
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid();
            CarImages = new List<CarImage>();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public string? Model { get; private set; }

        public string? Color { get; private set; }

        public string? LicensePlate { get; private set; } // پلاک خودرو 

        public string? VIN { get; private set; }  //مخفف => Vehicle Identification Number (VIN) 

        public int? ManufactureYear { get; private set; }

        public int? Mileage { get; private set; } // میزان کارکرد خودرو 

        public CarStatus? CarStatus { get; private set; }

        public salestatus? Salestatus { get; private set; }

        public Guid BrandId { get; private set; }

        public int? TotalPrice { get; private set; }

        public Brand Brand { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CarImage> CarImages { get; set; }

        public void UpdateCar(
            string? color,
            string? model,
            int? manufactureYear,
            string? licensePlate,
            int? mileage,
            string? vIN,
            int? totalPrice,
            CarStatus? carStatus,
            salestatus? salestatus)
        {
            if (!string.IsNullOrEmpty(color) && color != "string")
            {
                Color = color;
            }

            if (!string.IsNullOrEmpty(model) && model!= "string")
            {
                Model = model;
            }

            if (manufactureYear.HasValue && manufactureYear.Value!=0)
            {
                ManufactureYear = manufactureYear;
            }

            if (!string.IsNullOrEmpty(licensePlate) && licensePlate!= "string")
            {
                LicensePlate = licensePlate;
            }

            if (!string.IsNullOrEmpty(vIN) && vIN!= "string")
            {
                VIN = vIN;
            }

            if (mileage.HasValue && mileage.Value != 0)
            {
                Mileage = mileage;
            }

            if (totalPrice.HasValue && totalPrice.Value != 0)
            {
                TotalPrice = totalPrice;
            }

            if (carStatus.HasValue && carStatus.Value!=0)
            {
                CarStatus = carStatus.Value;
            }

            if (salestatus.HasValue && salestatus.Value != 0)
            {
                Salestatus = salestatus.Value;
            }
        }

        public void updatestatus(salestatus newsalestatus)
        {
            Salestatus = newsalestatus;
        }

    }
    public enum CarStatus
    {
        LowUsage,
        HighUsage
    }
    public enum salestatus
    {
        Purchased,
        NotSold,
        Unavailable,
        pendingreview
    }


}
