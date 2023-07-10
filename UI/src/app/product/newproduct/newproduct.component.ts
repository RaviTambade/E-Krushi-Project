import { Component, EventEmitter, Output } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from 'src/app/product';
import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-newproduct',
  templateUrl: './newproduct.component.html',
  styleUrls: ['./newproduct.component.css']
})
export class NewproductComponent {
  message: string | undefined;
  progress: number =0;
  file:any;
  product:Product={
    id: 0,
    title: '',
    unitPrice: 0,
    stockAvailable: 0,
    image: '',
    categoryId: 0,
    categoryTitle:''
  }

  status:Boolean | undefined;
  @Output() public onUploadFinished = new EventEmitter();
  constructor(private svc:ProductService,private http:HttpClient){}

  
 //get file info
 uploadFile = (files: any) => {
  if (files.length === 0) {
    return;
  }
  this.file = <File>files[0];
  console.log(this.file.name);
}

onSubmit(form:any){
//set material value  
this.product.image= "/assets/img/"+this.file.name;
    this.svc.newProduct(this.product).subscribe((res)=>{
      this.status=res;
      console.log("Insert is Called"+ res);
    });
    //save image in Rest API
  const formData = new FormData();
  formData.append('file', this.file, this.file.name);

  this.http.post('http://localhost:5137/api/products/uploadfile', formData, { reportProgress: true, observe: 'events' })
    .subscribe({
      next: (event) => {
        console.log(event);
         if (event.type === HttpEventType.UploadProgress && event.total) 
         this.progress = Math.round(100 * event.loaded / event.total);
        if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      },
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }
}
