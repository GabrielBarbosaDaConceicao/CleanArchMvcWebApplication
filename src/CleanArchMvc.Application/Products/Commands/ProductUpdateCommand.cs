namespace CleanArchMvc.Application.Products.Commands
{
    public sealed class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}