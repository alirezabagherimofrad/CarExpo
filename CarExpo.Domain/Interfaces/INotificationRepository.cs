using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
    }
}
