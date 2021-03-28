import { Component, OnInit } from '@angular/core';
import { Draw } from 'src/Model/draw.model';
import { timer } from 'rxjs';
import { DataService } from '../Services/data.service';
import { StorageService } from '../Services/storage.service';
import { tap } from 'rxjs/operators';
import { trigger } from '@angular/animations';

@Component({
  selector: 'app-lets-play',
  templateUrl: './lets-play.component.html',
  styleUrls: ['./lets-play.component.scss']
})
export class LetsPlayComponent implements OnInit {
  
  constructor(private dataService: DataService, private storageService: StorageService){

  }  
  

  rollDisplay = false;
  rollDisplay1 = false;
  rollDisplay2 = false;
  rollDisplay3 = false;
  rollDisplay4 = false;
  rollDisplay5 = false;

  drawBtnEnabled = false;

  drawBtnLabel = "Draw"
  public draw: Draw;
  errorMessages: any;

  
  ngOnInit(): void {
  }

  getDraw(){
    this.rollDisplay1 =false;
    this.rollDisplay2 =false;
    this.rollDisplay3 =false;
    this.rollDisplay4 =false;
    this.rollDisplay5 =false;
    this.drawBtnEnabled = true;
    this.runDraw();
  }

  runDraw(){
    this.drawBtnLabel = "Draw again"
    this.drawRandomNumber();
    this.saveDrowToDb();
    this.showNewDraw();
  }
  
  showNewDraw(){
    timer(100).subscribe(x => { this.rollDisplay1 = !this.rollDisplay1;
    });
    timer(200).subscribe(x => { this.rollDisplay2 = !this.rollDisplay2;
    });
    timer(300).subscribe(x => { this.rollDisplay3 = !this.rollDisplay3;
    });
    timer(400).subscribe(x => { this.rollDisplay4 = !this.rollDisplay4;
    });
    timer(500).subscribe(x => { 
      this.rollDisplay5 = !this.rollDisplay5;
      this.drawBtnEnabled = false;
    });
  }

  drawRandomNumber(){
    var min = 1;
    var max = 50;

    this.draw = new Draw();
    this.draw.drawDateTime = new Date();

    var number = this.getRandomInt(min,max);
    this.draw.drawNumber1 = number;
    while(this.draw.drawNumber1 == number){
      var number = this.getRandomInt(min,max);      
    }
    this.draw.drawNumber2 = number;
    while(this.draw.drawNumber1 == number ||this.draw.drawNumber2 == number){
      var number = this.getRandomInt(min,max);      
    }
    this.draw.drawNumber3 = number;
    while(this.draw.drawNumber1 == number||this.draw.drawNumber2 == number || this.draw.drawNumber3 == number){
      var number = this.getRandomInt(min,max);      
    }
    this.draw.drawNumber4 = number;
    while(this.draw.drawNumber1 == number||this.draw.drawNumber2 == number ||this.draw.drawNumber3 == number || this.draw.drawNumber4 == number){
      var number = this.getRandomInt(min,max);      
    }
    this.draw.drawNumber5 = number;

  }
 
  getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min); 
  }

  private saveDrowToDb(){

    let url = this.storageService.retrieve('baseUrl') + "api/Draw/SaveDraw";

    let setDrawObserve = this.dataService.post(url, this.draw).pipe<boolean>(tap((response: any) => true));

    setDrawObserve.subscribe(
      x => {
          this.errorMessages = [];
          console.log('Draw save: ' + x);
      },
      errMessage => this.errorMessages = errMessage.messages);
  }
 
}