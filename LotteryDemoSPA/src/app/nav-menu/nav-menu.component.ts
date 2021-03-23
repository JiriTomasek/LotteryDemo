import { Component, OnInit } from '@angular/core';

import { faListAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  faListIcon = faListAlt;
  isExpanded = false;
  constructor() { }

  ngOnInit(): void {
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
