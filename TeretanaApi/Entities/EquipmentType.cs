using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class EquipmentType
    {
        [Key]
        public Guid EquipmentTypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
