namespace TeretanaApi.Model.GroupTraining
{
    public class GroupTrainingDto
    {
        public Guid GroupTrainingId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfGroupTraining { get; set; }
        public Guid GroupTrainingTypeId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string TrainerName { get; set; }
        public Guid TrainerId { get; set; }
     
        public int ActualUserCount { get; set; }
        public int UserCapacity { get; set; }
        public List<Guid> Users { get; set; }

    }
}
