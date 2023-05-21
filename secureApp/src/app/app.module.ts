import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RoutingComponent } from './routing/routing.component';
import { ProductComponent } from './product/product.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AboutUsComponent } from './about-us/about-us.component';

const routes : Routes=[
  {path:'' ,redirectTo:'/login' ,pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'product' ,component:ProductComponent}
]


 

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RoutingComponent,
    ProductComponent,
    AboutUsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
