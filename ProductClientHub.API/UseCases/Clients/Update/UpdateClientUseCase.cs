﻿using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.Infraestructure;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute ( Guid clientId, RequestsClientJson request)
    {
        Validate(request);

        var dbContext = new ProductClienteHubDbContext();

        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
        if (entity is null)
            throw new NotFoundException("Cliente não encontrado.");

        entity.Name = request.Name;
        entity.Email = request.Email;

        dbContext.Clients.Update(entity);
        dbContext.SaveChanges();
    }
    private void Validate(RequestsClientJson request)
    {
        var validator = new RequestClientValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
