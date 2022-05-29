import { Component, Input, OnInit } from '@angular/core';
import { MembershipType } from 'src/app/models/membershipType.model';

@Component({
  selector: 'app-membership-card',
  templateUrl: './membership-card.component.html',
  styleUrls: ['./membership-card.component.scss']
})
export class MembershipCardComponent implements OnInit {

  constructor() { }
  @Input() membershipType:MembershipType;

  ngOnInit(): void {
  }

}
