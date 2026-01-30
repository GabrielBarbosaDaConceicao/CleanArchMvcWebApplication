using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image) : this(name, description, price, stock, image)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
               "Invalid name. Name is required.");

            DomainValidationException.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainValidationException.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainValidationException.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainValidationException.When(price < 0, "Invalid price value.");

            DomainValidationException.When(stock < 0, "Invalid stock value.");

            DomainValidationException.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}