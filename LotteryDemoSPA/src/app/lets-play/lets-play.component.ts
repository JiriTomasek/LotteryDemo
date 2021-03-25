import { Component, OnInit } from '@angular/core';
import { Draw } from 'src/Model/draw.model';
import { timer } from 'rxjs';
import { DataServiceService } from '../Services/data-service.service';

@Component({
  selector: 'app-lets-play',
  templateUrl: './lets-play.component.html',
  styleUrls: ['./lets-play.component.scss']
})
export class LetsPlayComponent implements OnInit {
  
  constructor(private dataServiceService: DataServiceService){

  }  
  
  
  rollDisplay = false;
  drawBtnLabel = "Draw"
  public draw: Draw;

  
  ngOnInit(): void {
  }

  roll(){
    this.rollDisplay =false;
    timer(100).subscribe(x => { this.runRoll()
    });
    
  }

  runRoll(){
    this.rollDisplay = !this.rollDisplay;
    this.drawBtnLabel = "Draw again"
    this.drawRandomNumber();
  }
  
  drawRandomNumber(){
    this.draw = new Draw();

    var number = this.getRandomInt(1,55);
    this.draw.DrawNumber1 = number;
    while(this.draw.DrawNumber1 == number){
      var number = this.getRandomInt(1,55);      
    }
    this.draw.DrawNumber2 = number;
    while(this.draw.DrawNumber1 == number ||this.draw.DrawNumber2 == number){
      var number = this.getRandomInt(1,55);      
    }
    this.draw.DrawNumber3 = number;
    while(this.draw.DrawNumber1 == number||this.draw.DrawNumber2 == number || this.draw.DrawNumber3 == number){
      var number = this.getRandomInt(1,55);      
    }
    this.draw.DrawNumber4 = number;
    while(this.draw.DrawNumber1 == number||this.draw.DrawNumber2 == number ||this.draw.DrawNumber3 == number || this.draw.DrawNumber4 == number){
      var number = this.getRandomInt(1,55);      
    }
    this.draw.DrawNumber5 = number;

  }
 
  getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min); 
  }
 
}