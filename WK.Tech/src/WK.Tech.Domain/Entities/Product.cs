using WK.Tech.Core.DomainObjects;

namespace WK.Tech.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal ProductValue { get; private set; }
        public DateTime DataRegistration { get; private set; }
        public string Image { get; private set; }
        public int Quantity { get; private set; }
        public Category Category { get; private set; }

        protected Product()
        {
        }

        public Product(string name, string description, bool active, decimal productValue, Guid categoryId, string image)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            ProductValue = productValue;
            DataRegistration = DateTime.Now;
            Image = image;

            Validate();
        }

        public void Activate() => Active = true;

        public void Disable() => Active = false;

        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            if (!HaveStock(quantity)) throw new DomainException("Estoque insuficiente");
            Quantity -= quantity;
        }

        public void ReplenishStock(int quantity)
        {
            Quantity += quantity;
        }

        public bool HaveStock(int quantity)
        {
            return Quantity >= quantity;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "O campo Nome do produto não pode estar vazio");
            AssertionConcern.AssertArgumentNotEmpty(Description, "O campo Descricao do produto não pode estar vazio");
            AssertionConcern.AssertArgumentNotEquals(CategoryId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            AssertionConcern.AssertArgumentRange((double)ProductValue, 0, double.MaxValue, "O campo Valor do produto não pode se menor igual a 0");
            AssertionConcern.AssertArgumentNotEmpty(Image, "O campo Imagem do produto não pode estar vazio");
        }
    }
}
