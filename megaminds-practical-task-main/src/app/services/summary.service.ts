import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SummaryService {
  // private baseApiUrl: string = "http://localhost:3000/Data";
  private baseApiUrl: string = "https://localhost:44372/api";
  //https://localhost:44372/api/Construction/getAll

  constructor(private http: HttpClient) { }

  public getSummary(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}/Construction/getAll`);
  }
  
  public updateSummary(id: number, data: any) {
    return this.http.put(`${this.baseApiUrl}/${id}`, data);
  }
  
}
