import {  Component, OnInit, ViewChild } from '@angular/core';

import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import { Draw } from 'src/Model/draw.model';
import { StorageService } from '../Services/storage.service';
import { DataService } from '../Services/data.service';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { DatePipe } from '@angular/common';

const ELEMENT_DATA: Draw[] = [
  {drawDateTime: new Date(), drawNumber1: 1, drawNumber2: 1, drawNumber3: 1, drawNumber4: 1,drawNumber5: 1}
];



@Component({
  selector: 'app-draw-history',
  templateUrl: './draw-history.component.html',
  styleUrls: ['./draw-history.component.scss']
})
export class DrawHistoryComponent implements OnInit {
  displayedColumns: string[] = ['drawDateTime', 'drawNumber1', 'drawNumber2', 'drawNumber3', 'drawNumber4', 'drawNumber5'];
  drawHistoryData: Draw[] = ELEMENT_DATA;
  dataSource : any;
  @ViewChild(MatSort) sort: MatSort;  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  errorReceived: boolean;
  

  constructor(private dataService: DataService, private storageService: StorageService) { }
 

  ngOnInit(): void {

    this.getHistory();
  }
  private getHistory(){

    let url = this.storageService.retrieve('baseUrl') + "api/Draw/DrawHistory";

    let setDrawObserve =  this.dataService.get(url).pipe<Draw[]>(tap((response: any) => {return response}));


    setDrawObserve.pipe(catchError((err) => this.handleError(err))).subscribe(
      x => {
        this.drawHistoryData = x;
        this.dataSource = new MatTableDataSource(this.drawHistoryData);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
