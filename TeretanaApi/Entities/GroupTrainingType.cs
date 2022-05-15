using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class GroupTrainingType
    {
        [Key]
        public Guid GroupTrainingTypeId { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Description { get; set; }
        public int Duration { get; set; }


    }
}
