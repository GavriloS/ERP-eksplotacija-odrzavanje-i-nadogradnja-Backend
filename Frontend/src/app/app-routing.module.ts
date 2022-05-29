import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLoginComponent } from './auth/user-login/user-login.component';
import { UserRegisterComponent } from './auth/user-register/user-register.component';
import { BasketComponent } from './basket/basket.component';
import { AddProductComponent } from './form/add-product/add-product.component';
import { AddQuantityComponent } from './form/add-quantity/add-quantity.component';
import { GroupTrainingPageComponent } from './group-training-page/group-training-page.component';
import { HomeComponent } from './home/home.component';
import { MembershipPageComponent } from './membership-page/membership-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { StripeFailureComponent } from './stripe/stripe-failure/stripe-failure.component';
import { StripeSuccessComponent } from './stripe/stripe-success/stripe-success.component';


const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'membershipTypes',component:MembershipPageComponent},
  {path: 'login',component:UserLoginComponent},
  {path: 'register',component:UserRegisterComponent},
  {path:'products',component:ProductPageComponent},
  {path:'product/:prodId',component:SingleProductComponent},
  {path:'groupTrainings',component:GroupTrainingPageComponent},
  {path:'basket',component:BasketComponent},
  {path:'success',component:StripeSuccessComponent},
  {path:'failure',component:StripeFailureComponent},
  {path:'add/product',component:AddProductComponent},
  {path:'add/quantity/:id',component:AddQuantityComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
