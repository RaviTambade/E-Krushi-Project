import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import {  authRoutes } from './authentication/authentication.module';
import { JWT_OPTIONS, JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { catlogRoutes } from '@ekrushi-catalog/catalog.module';
import { consultingRoutes } from '@ekrushi-consulting/consulting.module';
import { shipperRoutes } from '@ekrushi-shipper/shipper.module';
import { supplierRoutes } from '@ekrushi-supplier/supplier.module';
// import { OrderService } from '@services/order-service.service';
import { storeRoutes } from '@ekrushi-storeowner/store-owner.module';
import { orderProcessingRoutes } from '@ekrushi-orderprocessing/order-processing.module';
import { BrandingModule } from './branding/branding.module';
import { pagesRoutes } from './pagesmodule/pagesmodule.module';
import { crmRoutes } from '@ekrushi-crm/crm.module';
import { LocalStorageKeys } from '@enums/local-storage-keys';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatDialogModule,
    MatSnackBarModule,
    BrandingModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem(LocalStorageKeys.jwt),
        allowedDomains: ['localhost:5142', 'localhost:5263'],
      },
    }),

    RouterModule.forRoot([
      { path: '', children: pagesRoutes },
      { path: 'auth', children: authRoutes },
      { path: 'crm', children: crmRoutes },
      { path: 'catalog', children: catlogRoutes },
      { path: 'shipper', children: shipperRoutes },
      { path: 'store', children: storeRoutes },
      { path: 'supplier', children: supplierRoutes },
      { path: 'orderprocessing', children: orderProcessingRoutes },
      { path: 'consulting', children: consultingRoutes },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [
    // OrderService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
