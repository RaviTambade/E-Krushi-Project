import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit{

  question:any;
  id:number | any;
constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){}

  ngOnInit(): void {
   }
  getQuestion(id:number){
    this.id=this.route.snapshot.paramMap.get("id");
    this.svc.getQuestion(this.id).subscribe((res)=>{
      this.question=res;
      console.log(this.question);
    })
  }

}
