using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeretanaApi.Entities
{
    public class GroupTraining
    {
        [Key]
        public Guid GroupTrainingId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfGroupTraining { get; set; }
        public Guid GroupTrainingTypeId { get; set; }
        public int UserCapacity { get; set; }
        public int ActualUserCount { get; set; }
        public GroupTrainingType GroupTrainingType { get; set; }
        [ForeignKey("User")]
        public Guid TrainerId { get; set; }
        public User Trainer { get; set; }
        public virtual List<User> Users { get; set; }
     

    }
}
