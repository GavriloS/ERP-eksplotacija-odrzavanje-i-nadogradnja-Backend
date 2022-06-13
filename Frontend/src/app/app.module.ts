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
import {SidebarModule} from 'primeng/sidebar';
import {RippleModule} from 'primeng/ripple';
import {TableModule} from 'primeng/table';
import {DialogModule} from 'primeng/dialog';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {ChartModule} from 'primeng/chart';
import {DataViewModule} from 'primeng/dataview';
import {ListboxModule} from 'primeng/listbox';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService} from 'primeng/api';

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
import { AdminPageComponent } from './admin-page/admin-page.component';
import { ChartPageComponent } from './admin-page/chart-page/chart-page.component';
import { TablePageComponent } from './admin-page/table-page/table-page.component';
import { EquipmentDialogComponent } from './admin-page/dialog/equipment-dialog/equipment-dialog.component';
import { DeleteDialogComponent } from './admin-page/dialog/delete-dialog/delete-dialog.component';
import { SuplementDialogComponent } from './admin-page/dialog/suplement-dialog/suplement-dialog.component';
import { TableWithoutButtonsComponent } from './admin-page/table-without-buttons/table-without-buttons.component';
import { BasketDialogComponent } from './admin-page/dialog/basket-dialog/basket-dialog.component';
import { UserPageComponent } from './user-page/user-page.component';
import { MembershipTypeDialogComponent } from './admin-page/dialog/membership-type-dialog/membership-type-dialog.component';
import { SuccessMembershipComponent } from './stripe/success-membership/success-membership.component';
import { BasketTableComponent } from './user-page/basket-table/basket-table.component';
import { GrouptrainingTypeDialogComponent } from './admin-page/dialog/grouptraining-type-dialog/grouptraining-type-dialog.component';
import { EquipmentTypeDialogComponent } from './admin-page/dialog/equipment-type-dialog/equipment-type-dialog.component';
import { SuplementTypeDialogComponent } from './admin-page/dialog/suplement-type-dialog/suplement-type-dialog.component';
import { AddGroupTrainingDialogComponent } from './group-training-page/dialog/add-group-training-dialog/add-group-training-dialog.component';
import { ParticipateDialogComponent } from './group-training-page/dialog/participate-dialog/participate-dialog.component';
import { GroupTrainingTableComponent } from './user-page/group-training-table/group-training-table.component';
import { UserDialogComponent } from './admin-page/dialog/user-dialog/user-dialog.component';






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
    AddQuantityComponent,
    AdminPageComponent,
    ChartPageComponent,
    TablePageComponent,
    EquipmentDialogComponent,
    DeleteDialogComponent,
    SuplementDialogComponent,
    TableWithoutButtonsComponent,
    BasketDialogComponent,
    UserPageComponent,
    MembershipTypeDialogComponent,
    SuccessMembershipComponent,
    BasketTableComponent,
    GrouptrainingTypeDialogComponent,
    EquipmentTypeDialogComponent,
    SuplementTypeDialogComponent,
    AddGroupTrainingDialogComponent,
    ParticipateDialogComponent,
    GroupTrainingTableComponent,
    UserDialogComponent




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
    FullCalendarModule,
    SidebarModule,
    RippleModule,
    TableModule,
    DialogModule,
    InputTextareaModule,
    ChartModule,
    DataViewModule,
    ListboxModule,
    ConfirmDialogModule,


  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
