import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public url = 'http://localhost:5000';

constructor(private http: HttpClient) { }

public get(caminho: string): Observable<any>{
  return this.http.get<any>(`${this.url}/${caminho}`);
}

public getL(caminho: string, obj:any): Observable<any>{
  return this.http.get<any>(`${this.url}/${caminho}`, obj);
}

public post(caminho: string, obj: any ): Observable<any>{
  return this.http.post<any>(`${this.url}/${caminho}`, obj);
}



public delete(caminho: string, id: string ): Observable<any>{
  return this.http.delete<any>(`${this.url}/${caminho}/${id}`);
}
public deleteId(caminho: string, id: number ): Observable<any>{
  return this.http.delete<any>(`${this.url}/${caminho}/${id}`);
}


}
