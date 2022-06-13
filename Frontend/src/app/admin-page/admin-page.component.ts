import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {

  showChart:boolean = true;
  tableName:string;
  showTableWithButtons:boolean = false;
  showTableWithoutButtons:boolean = false;

  constructor(private authService:AuthService) { }

  ngOnInit(): void {
  }

  changeTable(tableName:string){


    this.tableName = tableName;
    this.showTableWithButtons = true;
    this.showTableWithoutButtons = false;
    this.showChart = false;

  }
  changeToChart(){
    this.showChart = true;
    this.showTableWithButtons = false;
    this.showTableWithoutButtons = false;
  }
  onLogout(){
    this.authService.logout();
  }

  changeTableWithoutButtons(tableName:string){
    this.showTableWithButtons = false;
    this.showTableWithoutButtons = true;
    this.tableName = tableName;
    this.showChart = false;
  }

}
