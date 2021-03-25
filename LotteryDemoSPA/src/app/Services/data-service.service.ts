import { Injectable } from '@angular/core';
import { Draw } from 'src/Model/draw.model';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  constructor(private http: HttpClient) { }

  ChangeLang(draw : Draw){
    
  }
}
