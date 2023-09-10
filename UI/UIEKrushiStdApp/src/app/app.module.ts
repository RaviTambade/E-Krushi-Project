import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutUsComponent } from './AboutUs/AboutUs.component';
import { ContactUsComponent } from './ContactUs/ContactUs.component';
import { LoginComponent } from './authentication/login/login.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { customerRoutes } from './customer/customer.module';
import { shipperRoutes } from './shipper/shipper.module';
import { shopRoutes } from './shop-owner/shop-owner.module';
import { subjetcMatterExpertRoutes } from './subject-matter-expert/subject-matter-expert.module';
import { supplierRoutes } from './supplier/supplier.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutUsComponent,
    ContactUsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AuthenticationModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'AboutUs', component: AboutUsComponent },
      { path: 'home', component: HomeComponent },
      { path: 'ContactUs', component: ContactUsComponent },
      { path: 'login', component: LoginComponent },
      {path:'customer',children:customerRoutes},
      {path:'shipper',children:shipperRoutes},
      {path:'shop',children:shopRoutes},
      {path:'sme',children:subjetcMatterExpertRoutes},
      {path:'supplier',children:supplierRoutes},

    ])
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
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
