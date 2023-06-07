import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from './aap.service';


interface Country {
  shortName: string;
  name: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';

  form: FormGroup;
  //matcher = new MyErrorStateMatcher();

  countries: any;
  states: string[];
  cities: string[];

  country = new FormControl(null, [Validators.required]);

  state = new FormControl({ value: null, disabled: true }, [Validators.required,]);
  city = new FormControl({ value: null, disabled: true }, [Validators.required,]);
  
  constructor(private service: AppService) {
    //fetch all available countries from service
    this.countries = this.service.getCountries();

    this.form = new FormGroup({
      country: this.country,
      state: this.state,
      city: this.city,
    });
  }
  

}
