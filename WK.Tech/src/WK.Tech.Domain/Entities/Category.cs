using WK.Tech.Core.DomainObjects;

namespace WK.Tech.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        // EF Relation
        public ICollection<Product> Products { get; set; }

        protected Category() { }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;

            Validate();
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "O campo Nome da categoria não pode estar vazio");
            AssertionConcern.AssertArgumentEquals(Code, 0, "O campo Código não pode ser 0");
        }
    }
}
