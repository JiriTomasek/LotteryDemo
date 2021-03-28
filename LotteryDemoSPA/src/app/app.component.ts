import { Component } from '@angular/core';
import { StorageService } from './Services/storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'LotteryDemoSPA';

  constructor(private storageService: StorageService) {
}

  ngOnInit() {
  this.storageService.store('baseUrl', "http://localhost:5001/")
}


}
