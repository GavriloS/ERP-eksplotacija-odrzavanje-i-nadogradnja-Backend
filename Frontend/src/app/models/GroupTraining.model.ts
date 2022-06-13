export interface GroupTraining{
  groupTrainingId:string,
  dateTimeOfGroupTraining:Date,
  groupTrainingTypeId:string,
  trainerId:string,
  actualUserCount:number,
  userCapacity:number,
  name:string;
  duration:number;
  trainerName:string
  users:string[];
}
