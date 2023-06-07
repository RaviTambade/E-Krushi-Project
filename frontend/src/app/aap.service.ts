import { Injectable } from '@angular/core';


@Injectable()
export class AppService {

  getCountries() {
    //return this.countryData.getCountries();
    let countries=[
        {"name":"India","shortName": "IN"},
        {"name":"China","shortName": "Chin"},
        {"name":"America","shortName": "USA"},
    ]
    return countries;
  }


  getStatesByCountry(country: string):any {
   let  states:any;
    switch(country){
        case "India":
        states=["Maharashtra", "Gujrat","Goa"];
        return  states;
        break;
        case "China":

        break;
        case "America":
        break;

    }
    return states;
  }

  getCitiesByState(country: string, state: string) {
    let cities:any;
    
    return  cities;
  }
}
