using System.ComponentModel.DataAnnotations;

namespace auto.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display (Name ="Название бренда")]
        public string Name { get; set; }

        public List<Model> Models { get; set; }


        public bool Active { get; set; }
    }
}
