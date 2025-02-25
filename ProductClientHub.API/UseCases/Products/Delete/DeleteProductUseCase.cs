using ProductClientHub.API.Infraestructure;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClienteHubDbContext();
            var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);
            if (entity is null)
                throw new DirectoryNotFoundException("Produto não encontrado.");

            dbContext.Products.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
