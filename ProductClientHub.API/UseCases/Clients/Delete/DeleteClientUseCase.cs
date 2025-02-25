using ProductClientHub.API.Entities;
using ProductClientHub.API.Infraestructure;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClienteHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(Client => Client.Id == id);
            if (entity is null)
                throw new DirectoryNotFoundException("Cliente não encontrado.");

            dbContext.Products.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
