import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Solution } from './solution';

@Injectable({
  providedIn: 'root'
})
export class SolutionService {

  constructor(private http:HttpClient) { }

  public getAllSolutions():Observable<any>{
    let url= "http://localhost:5241/solutions/getallsolutions";
    return this.http.get<any>(url);
  }

  public getSolution(solutionId:number):Observable<any>{
    let url= "http://localhost:5241/solutions/getbyid/"+ solutionId;
    return this.http.get<any>(url);
  }

  public deleteSolution(solutionId:number):Observable<any>{
    let url= "http://localhost:5241/solutions/deletesolution/"+ solutionId;
    return this.http.delete<any>(url);
  }

  public addSolution(solution:Solution):Observable<any>{
    let url= "http://localhost:5241/solutions/insertsolution";
    return this.http.post<any>(url,solution);
  }

  public updateSolution(solution:Solution):Observable<any>{
    let url= "http://localhost:5241/solutions/updatesolution";
    return this.http.put<any>(url,solution);
  }
}
