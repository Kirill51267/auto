using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace auto.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }

        [Display(Name = "Название модели")]
        public string Name { get; set; }   

        public Brand Brand { get; set; }

        public bool Active { get; set; }
    }
}
