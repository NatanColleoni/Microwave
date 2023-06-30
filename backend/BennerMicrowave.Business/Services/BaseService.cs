using BennerMicrowave.Data.Exception;
using BennerMicrowave.Data.Seedwork.Enums;
using BennerMicrowave.Data.Seedwork.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace BennerMicrowave.Business.Services
{
    public abstract class BaseService
    {
        public virtual ValidationResult ValidationResult { get; protected set; }
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
            catch(BadRequestErrorException e)
            {
                _notification.AddNotification("Bad Request", e.Message, ENotificationType.BadRequestError);
            }
            catch(BusinessRulesErrorException e)
            {
                _notification.AddNotification("Business Rules Error", e.Message, ENotificationType.BusinessRulesError);
            }
            catch (Exception e)
            {
                _notification.AddNotification("Internal Error", e.Message, ENotificationType.InternalServerError);
            }

            return default;
        }

        public virtual void Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);

            if(!ValidationResult.IsValid)
            {
                foreach(var error in ValidationResult.Errors)
                {
                    _notification.AddNotification(error.PropertyName, error.ErrorMessage, ENotificationType.BusinessRulesError);
                }
                throw new BusinessRulesErrorException();
            }
        }
    }
}
