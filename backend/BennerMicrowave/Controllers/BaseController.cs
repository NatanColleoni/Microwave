using BennerMicrowave.Business.Response;
using BennerMicrowave.Data.Seedwork.Enums;
using BennerMicrowave.Data.Seedwork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BennerMicrowave.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly INotification _notification;

        public BaseController(INotification notification)
        {
            _notification = notification;
        }

        private bool IsValidOperation() => !_notification.HasNotification;

        protected new IActionResult Response(BaseResponse response)
        {
            if (IsValidOperation())
            {
                if (response.Data == null || response == null)
                    return BadRequest(new BaseResponse { Success = false, Data = null }); // poderia ser um NoContent

                return Ok(response);
            }
            else
            {
                if (response == null)
                    response = new BaseResponse();

                response.Success = false;
                response.Data = _notification.ListNotificationModel;

                var notificationType = _notification.ListNotificationModel[0].NotificationType;

                return notificationType switch
                {
                    ENotificationType.BusinessRulesError => Conflict(response),
                    ENotificationType.BadRequestError => BadRequest(response),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, response),
                };
            }
        }
    }
}
