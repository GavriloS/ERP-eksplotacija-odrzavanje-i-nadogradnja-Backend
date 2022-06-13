namespace TeretanaApi.Model.GroupTraining
{
    public class GroupTrainingUpdateDto
    {
        public Guid GroupTrainingId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfGroupTraining { get; set; }
        public Guid GroupTrainingTypeId { get; set; }
        public Guid TrainerId { get; set; }
        public int UserCapacity { get; set; }
        public int ActualUserCount { get; set; }
        
    }
}
