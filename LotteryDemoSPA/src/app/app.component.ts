import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
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
  this.storageService.store('baseUrl', environment.LotteryDemoApiUrl)
}


}
