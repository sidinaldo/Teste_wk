using System.ComponentModel.DataAnnotations;

namespace WK.Tech.Domain.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            Categories = new List<CategoryDto>();   
        }


        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ProductValue { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantity { get; set; }

        public virtual IEnumerable<CategoryDto> Categories { get; set; }
    }
}
