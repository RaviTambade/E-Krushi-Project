import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { LoginComponent } from './authentication/login/login.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { customerRoutes } from './customer/customer.module';
import { shipperRoutes } from './shipper/shipper.module';
import { shopRoutes } from './shop-owner/shop-owner.module';
import { subjetcMatterExpertRoutes } from './subject-matter-expert/subject-matter-expert.module';
import { supplierRoutes } from './supplier/supplier.module';
import { SecondaryNavMenuComponent } from './secondary-nav-menu/secondary-nav-menu.component';
import { AboutUsComponent } from './AboutUs/AboutUs.component';
import { ContactUsComponent } from './ContactUs/ContactUs.component';
import { ProductNavbarComponent } from './product-navbar/product-navbar.component';
import { CatalogModule } from './catalog/catalog.module';
import { ShoppingcartComponent } from './catalog/shoppingcart/shoppingcart.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SecondaryNavMenuComponent,
    AboutUsComponent,
    ContactUsComponent,
    ProductNavbarComponent
    
    
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AuthenticationModule,
    CatalogModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'aboutus', component: AboutUsComponent },
      { path: 'home', component: HomeComponent },
      { path: 'shoppingcart', component: ShoppingcartComponent },
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
