import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UserLoginComponent } from './auth/user-login/user-login.component';
import { UserRegisterComponent } from './auth/user-register/user-register.component';
import { BasketComponent } from './basket/basket.component';
import { AddProductComponent } from './form/add-product/add-product.component';
import { AddQuantityComponent } from './form/add-quantity/add-quantity.component';
import { GroupTrainingPageComponent } from './group-training-page/group-training-page.component';
import { HomeComponent } from './home/home.component';
import { MembershipPageComponent } from './membership-page/membership-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { AuthGuard } from './services/auth.guard';
import { LoginGuard } from './services/login.guard';
import { SingleProductComponent } from './single-product/single-product.component';
import { StripeFailureComponent } from './stripe/stripe-failure/stripe-failure.component';
import { StripeSuccessComponent } from './stripe/stripe-success/stripe-success.component';
import { SuccessMembershipComponent } from './stripe/success-membership/success-membership.component';
import { UserPageComponent } from './user-page/user-page.component';


const routes: Routes = [
  {path:'',component:ProductPageComponent},
  {path:'membershipTypes',component:MembershipPageComponent},
  {path: 'login',component:UserLoginComponent,canActivate:[LoginGuard]},
  {path: 'register',component:UserRegisterComponent,canActivate:[LoginGuard]},
  {path:'product/:prodId',component:SingleProductComponent},
  {path:'groupTrainings',component:GroupTrainingPageComponent},
  {path:'basket',component:BasketComponent,canActivate:[AuthGuard]},
  {path:'success/membership/:id',component:SuccessMembershipComponent},
  {path:'success',component:StripeSuccessComponent},
  {path:'failure',component:StripeFailureComponent},
  {path:'add/product',component:AddProductComponent},
  {path:'add/quantity/:id',component:AddQuantityComponent},
  {path:'admin',component:AdminPageComponent,canActivate:[AuthGuard],data:{role:'Admin'}},
  {path:'user',component:UserPageComponent},
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard,LoginGuard]

})
export class AppRoutingModule { }
