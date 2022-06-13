import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from 'src/app/models/User.model';
import { UserService } from 'src/app/services/user.service';
import {AuthService} from 'src/app/services/auth.service'

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {

  constructor(private userService:UserService,
              private authService: AuthService) { }

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() user:User;
  @Input() mode:string;



  ngOnInit(): void {
    if(!!this.user){

    }else{
       this.user = new User(null,null,null,null,null,null,null,null,null,null,null,null,null,null);
    }
  }



  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){
    if(this.mode === 'm'){
      this.userService.modifyUser(this.user).subscribe(u =>{
        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.user.userTypeId = '51371A38-00FA-4171-BE2C-002E483ED463';
      this.user.numberOfGroupTraings =0;
      this.user.numberOfTrainings = 0;
      this.user.addressId = '708e252d-0f7a-44e8-fcd7-08da4d61f461';
      this.authService.signUp(this.user)
    }
  }
}
