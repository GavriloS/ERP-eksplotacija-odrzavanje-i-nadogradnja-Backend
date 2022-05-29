import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddressService } from 'src/app/services/adress.service';
import { AuthService } from 'src/app/services/auth.service';
import{Address} from '../../models/Address.model'
import{User} from '../../models/User.model'

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent implements OnInit {

  constructor(private addressService:AddressService,
              private authService:AuthService) { }

  ngOnInit(): void {
  }

  onRegister(form:NgForm)
  {
     let address :Address = {
       addressId:null,
      street:form.value.street,
      streetNumber:form.value.streetNumber,
      city:form.value.city,
      postalCode:form.value.postalCode
    };
    let addressId:string;
    this.addressService.addAddress(address)
    .subscribe(res =>{
        let user = new User (
          null,
          form.value.firstName,
          form.value.lastName,
          form.value.email,
          form.value.password,
          form.value.contact,
          null,
          null,
          res.addressId,
          null,
          '6BC0CC6A-C600-4AE9-8E2E-D4B61B601701',
          null,
          null,
          null

        );
        this.authService.signUp(user)




      });



  }

}
