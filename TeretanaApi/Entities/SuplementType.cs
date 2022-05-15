using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    
    public class SuplementType
    {
        [Key]
        public Guid SuplementTypeId { get; set; } = Guid.NewGuid();

        
        public String Name { get; set; }


    }
}
