namespace TeretanaApi.Model.GroupTraining
{
    public class GroupTrainingCreateDto
    {
        public DateTime DateTimeOfGroupTraining { get; set; }
        public Guid GroupTrainingTypeId { get; set; }
        public Guid TrainerId { get; set; }
        public int UserCapacity { get; set; }
        public int ActualUserCount { get; set; }
    }
}
