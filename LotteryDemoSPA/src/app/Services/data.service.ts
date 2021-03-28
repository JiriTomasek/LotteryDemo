import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";

import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { 
    
  }
  get(url: string, params?: any): Observable<Response> {
    let options = { };
    this.setHeaders(options);
    
    return this.http.get(url, options)
        .pipe(
            // retry(3), // retry a failed request up to 3 times
            tap((res: Response) => {
                return res;
            }),
            catchError(this.handleError)
            );
  }
  
  post(url: string, data: any): Observable<Response> {
    let options = { };
        this.setHeaders(options);
    return this.http.post(url, data, options)
        .pipe(
            tap((res: Response) => {
                return res;
            }),
            catchError(this.handleError)
        );
  }

  private setHeaders(options: any, needId?: boolean){
    
        options["headers"] = new HttpHeaders()
            .append('Content-Type', 'application/json')
            .append('Accept', '*/*')
            ;
   
}
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }
}
