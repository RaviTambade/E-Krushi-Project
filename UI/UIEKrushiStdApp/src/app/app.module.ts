import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './default/home/home.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { AboutUsComponent } from './default/AboutUs/AboutUs.component';
import { ContactUsComponent } from './default/ContactUs/ContactUs.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import {  MatSnackBarModule } from '@angular/material/snack-bar';
import { LoginComponent } from '@ekrushi-authentication/login/login.component';
import { CatalogModule, catlogRoutes } from '@ekrushi-catalog/catalog.module';
import { ConfirmationBoxComponent } from '@ekrushi-confirmationboxes/confirmation-box/confirmation-box.component';
import { DeleteConfirmationComponent } from '@ekrushi-confirmationboxes/delete-confirmation/delete-confirmation.component';
import { consultingRoutes } from '@ekrushi-consulting/consulting.module';
import { customerRoutes } from '@ekrushi-customer/customer.module';
import { shipperRoutes } from '@ekrushi-shipper/shipper.module';
import { subjetcMatterExpertRoutes } from '@ekrushi-subjectmatterexpert/subject-matter-expert.module';
import { supplierRoutes } from '@ekrushi-supplier/supplier.module';
import { userRoutes } from '@ekrushi-users/users.module';
import { OrderService } from '@services/order-service.service';
import { storeRoutes } from '@ekrushi-storeowner/store-owner.module';
import { orderProcessingRoutes } from '@ekrushi-orderprocessing/order-processing.module';
import { RegisterComponent } from '@ekrushi-authentication/register/register.component';
import { LoginRoutingComponent } from '@ekrushi-authentication/login-routing/login-routing.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutUsComponent,
    ContactUsComponent,
    DeleteConfirmationComponent,
    ConfirmationBoxComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AuthenticationModule,
    CatalogModule,
    MatDialogModule,
    MatSnackBarModule,
  
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'aboutus', component: AboutUsComponent },
      { path: 'home', component: HomeComponent },
      { path: 'login', component: LoginRoutingComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'user', children: userRoutes },
      { path: 'customer', children: customerRoutes },
      { path: 'catalog', children: catlogRoutes },
      { path: 'shipper', children: shipperRoutes },
      { path: 'shop', children: storeRoutes },
      { path: 'sme', children: subjetcMatterExpertRoutes },
      { path: 'supplier', children: supplierRoutes },
      { path: 'orderprocessing', children: orderProcessingRoutes },
      { path: 'consulting', children: consultingRoutes },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: JWT_OPTIONS,
      useValue: {
        tokenGetter: () => {
          return;
        },
        throwNoTokenError: true,
      },
    },
    JwtHelperService,
    OrderService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
