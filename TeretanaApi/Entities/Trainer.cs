using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Trainer
    {
        [Key]
        public Guid TrainerId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
