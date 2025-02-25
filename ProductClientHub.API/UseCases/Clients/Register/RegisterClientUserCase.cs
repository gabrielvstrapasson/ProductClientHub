using ProductClientHub.API.Entities;
using ProductClientHub.API.Infraestructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUserCase
    {
        public ResponseShortClientJson Execute(RequestsClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClienteHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };

            dbContext.Clients.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortClientJson()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        }
        private void Validate(RequestsClientJson request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);

            }
        }
    }
}