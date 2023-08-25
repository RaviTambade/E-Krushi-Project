import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UpdateComponent } from './update/update.component';
import { AppService } from './aap.service';
import { RadioComponent } from './radio/radio.component';
import { CheckBoxComponent } from './check-box/check-box.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { MutipleSelectListBoxComponent } from './mutiple-select-list-box/mutiple-select-list-box.component';
import { ProductgridComponent } from './productgrid/productgrid.component';
import { PaggingComponent } from './pagging/pagging.component';
import { SortedlistComponent } from './sortedlist/sortedlist.component';
import { ProductListDetailsComponent } from './product-list-details/product-list-details.component';
import { EmployeeModule } from './employee/employee.module';
import { RoutingComponent } from './employee/routing/routing.component';
import { CartModule } from './cart/cart.module';
import { AddtocartComponent } from './cart/addtocart/addtocart.component';
import { CategoryproductComponent } from './categoryproduct/categoryproduct.component';
import { CommonModule } from '@angular/common';
import { PaymentModule } from './payment/payment.module';
import { ConsultingModule } from './consulting/consulting.module';
import { ProductModule } from './product/product.module';
import { AuthenticationModule } from './authentication/authentication.module';
import { OrderModule } from './order/order.module';
import { ProductsaleModule } from './bi/productsale/productsale.module';
import { OrderchartModule } from './bi/orderchart/orderchart.module';
import { OrderstatusModule } from './bi/orderstatus/orderstatus.module';
import { ConsultingchartsModule } from './bi/consultingcharts/consultingcharts.module';
import { UsersModule } from './users/users.module';
import { faFontAwesome } from '@fortawesome/free-solid-svg-icons';


@NgModule({
  declarations: [
    AppComponent,   
    UpdateComponent,
    RadioComponent,
    CheckBoxComponent,
    FileUploadComponent,
    MutipleSelectListBoxComponent,
    ProductgridComponent,
    PaggingComponent,
    SortedlistComponent,
    ProductListDetailsComponent,
    CategoryproductComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    EmployeeModule,
    CartModule,
    PaymentModule,
    ConsultingModule,
    ProductModule,
    AuthenticationModule,
    OrderModule,
    OrderchartModule,
    ProductsaleModule,
    OrderstatusModule,
    ConsultingchartsModule,
    UsersModule,
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})

export class AppModule { }
