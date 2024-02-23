import { Component, OnInit } from '@angular/core';
import { NbMenuService } from '@nebular/theme';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'angular';
  constructor(private menuService: NbMenuService) { }
  ngOnInit(): void {
    this.menuService.onItemClick()
      .pipe(
        filter((event) => event.tag === 'menu-side-bar')
      )
      .subscribe(event => {
        this.deselected();
        event.item.selected = true;
        return event;
      });
  }
  private deselected() {
    this.menuService.getSelectedItem()
      .pipe(
        filter((event) => event.tag === 'menu-side-bar')
      )
      .subscribe(event => {
        event.item.selected = false;
      })
  }
}
