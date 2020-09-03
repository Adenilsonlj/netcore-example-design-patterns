using Example.Domain.SeedWork;
using Example.Domain.SeedWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.Common
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        public BaseService(INotification notification)
        {
            _notification = notification;
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (NotFoundException e)
            {
                _notification.AddNotification("Not Found", e.Message, NotificationModel.ENotificationType.NotFound);
                return default;
            }
            catch (Exception e)
            {
                _notification.AddNotification("Internal Error", e.Message, NotificationModel.ENotificationType.InternalServerError);
                return default;
            }
        }
    }
}
