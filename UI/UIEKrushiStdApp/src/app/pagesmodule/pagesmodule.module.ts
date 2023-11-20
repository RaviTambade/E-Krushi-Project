import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutUsComponent } from './AboutUs/AboutUs.component';
import { ContactUsComponent } from './ContactUs/ContactUs.component';
import { HomeComponent } from './home/home.component';
import { CatalogModule } from '@ekrushi-catalog/catalog.module';
import { RouterModule, Routes } from '@angular/router';

export const pagesRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'aboutus', component: AboutUsComponent },
  { path: 'home', component: HomeComponent },
];

@NgModule({
  declarations: [HomeComponent, AboutUsComponent, ContactUsComponent],
  imports: [CommonModule, CatalogModule,],
})
export class PagesmoduleModule {}
