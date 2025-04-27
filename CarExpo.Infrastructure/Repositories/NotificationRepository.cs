using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models;
using CarExpo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>,INotificationRepository
    {
        public NotificationRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
