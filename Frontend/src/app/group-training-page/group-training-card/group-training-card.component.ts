import { Component, OnInit,Input } from '@angular/core';
import { GroupTrainingType } from 'src/app/models/GroupTrainingType.model';

@Component({
  selector: 'app-group-training-card',
  templateUrl: './group-training-card.component.html',
  styleUrls: ['./group-training-card.component.scss']
})
export class GroupTrainingCardComponent implements OnInit {

  @Input() groupTrainingType:GroupTrainingType;

  constructor() { }



  ngOnInit(): void {

  }

}
