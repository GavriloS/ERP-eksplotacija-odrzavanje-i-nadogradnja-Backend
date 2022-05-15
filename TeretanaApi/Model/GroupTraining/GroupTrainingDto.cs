namespace TeretanaApi.Model.GroupTraining
{
    public class GroupTrainingDto
    {
        public Guid GroupTrainingId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfGroupTraining { get; set; }
        public Guid GroupTrainingTypeId { get; set; }
        public TeretanaApi.Entities.GroupTrainingType GroupTrainingType { get; set; }
 
        public TeretanaApi.Entities.User Trainer { get; set; }
        public virtual List<TeretanaApi.Entities.User> Users { get; set; }
    }
}
