import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import {ScrollingModule } from '@angular/cdk/scrolling'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {ButtonModule} from 'primeng/button';
import {ToolbarModule} from 'primeng/toolbar';
import {SplitButtonModule} from 'primeng/splitbutton';
import {MenuModule} from 'primeng/menu';
import {CardModule} from 'primeng/card';
import {InputTextModule} from 'primeng/inputtext';
import {DropdownModule} from 'primeng/dropdown';
import {PaginatorModule} from 'primeng/paginator';
import {InputNumberModule} from 'primeng/inputnumber';

import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin!
import interactionPlugin from '@fullcalendar/interaction'; // a plugin!
import timeGridPlugin from '@fullcalendar/timegrid';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { MembershipPageComponent } from './membership-page/membership-page.component';
import { MembershipCardComponent } from './membership-page/membership-card/membership-card.component';
import { UserRegisterComponent } from './auth/user-register/user-register.component';
import { UserLoginComponent } from './auth/user-login/user-login.component';
import { AuthInterceptor } from './services/auth-interceptor';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductCardComponent } from './product-page/product-card/product-card.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { GroupTrainingPageComponent,EventActionsComponent } from './group-training-page/group-training-page.component';
import { GroupTrainingCardComponent } from './group-training-page/group-training-card/group-training-card.component';
import { BasketComponent } from './basket/basket.component';
import { StripeSuccessComponent } from './stripe/stripe-success/stripe-success.component';
import { StripeFailureComponent } from './stripe/stripe-failure/stripe-failure.component';
import { AddProductComponent } from './form/add-product/add-product.component';
import { AddQuantityComponent } from './form/add-quantity/add-quantity.component';




FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  interactionPlugin,
  timeGridPlugin
]);

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    MembershipPageComponent,
    MembershipCardComponent,
    UserRegisterComponent,
    UserLoginComponent,
    ProductPageComponent,
    ProductCardComponent,
    SingleProductComponent,
    GroupTrainingPageComponent,
    GroupTrainingCardComponent,
    EventActionsComponent,
    BasketComponent,
    StripeSuccessComponent,
    StripeFailureComponent,
    AddProductComponent,
    AddQuantityComponent




  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ButtonModule,
    ToolbarModule,
    SplitButtonModule,
    MenuModule,
    CardModule,
    HttpClientModule,
    InputTextModule,
    DropdownModule,
    ScrollingModule,
    BrowserAnimationsModule,
    PaginatorModule,
    InputNumberModule,
    FullCalendarModule
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
