import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbMenuItem, NbMenuModule } from '@nebular/theme';

@Component({
  selector: 'app-menu-bar',
  standalone: true,
  imports: [NbMenuModule],
  templateUrl: './app-menu-bar.component.html',
  styleUrl: './app-menu-bar.component.scss'
})
export class AppMenuBarComponent implements OnInit {
  menuItems: NbMenuItem[] = [
    {
      title: 'Category',
      link: 'category',
      icon: 'credit-card',
    },
    {
      title: 'Book',
      link: 'book',
      icon: 'gift'
    }
  ];
  constructor(private _router: Router) {
  }
  ngOnInit() {
    this.getSelectedItem();
  }

  private getSelectedItem() {
    if (this._router.url === '/') {
      this.menuItems[1].selected = true;
      return;
    }
    this.menuItems.forEach(element => {
      if (this._router.url.startsWith('/' + element.link)) {
        element.selected = true;
      }
    })
  }
}
