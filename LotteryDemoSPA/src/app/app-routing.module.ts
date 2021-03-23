import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LetsPlayComponent } from './lets-play/lets-play.component';
import { DrawHistoryComponent } from './draw-history/draw-history.component';

const routes: Routes = [{ path: '', redirectTo: 'home',  pathMatch: 'full' },
{ path: 'home', component: HomeComponent },
{ path: 'lets-play', component: LetsPlayComponent },
{ path: 'DrawHistory', component: DrawHistoryComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
