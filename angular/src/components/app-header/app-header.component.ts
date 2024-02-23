import { Component, OnInit } from '@angular/core';
import { NbActionsModule, NbContextMenuModule, NbIconModule, NbMenuService, NbSelectModule, NbSidebarService, NbThemeService, NbUserModule } from '@nebular/theme';

@Component({
  selector: 'app-app-header',
  standalone: true,
  imports: [NbActionsModule, NbIconModule, NbSelectModule, NbUserModule, NbContextMenuModule],
  templateUrl: './app-header.component.html',
  styleUrl: './app-header.component.scss'
})
export class AppHeaderComponent implements OnInit {

  items = [
    { title: 'Profile' },
    { title: 'Logout' },
  ];
  selectedTheme: string = 'default';

  constructor(private themeService: NbThemeService,
    private menuService: NbMenuService,
    private sidebarService: NbSidebarService) { }

  ngOnInit() {
    this.themeService.changeTheme(this.selectedTheme);
    this.sidebarService.compact('nb-sidebar');
  }
  changeTheme() {
    this.themeService.changeTheme(this.selectedTheme);
  }
  collapse() {
    this.sidebarService.getSidebarState('nb-sidebar')
      .subscribe(state => {
        if (state === 'compacted') {
          this.sidebarService.expand('nb-sidebar');
        }
        else if (state === 'expanded') {
          this.sidebarService.compact('nb-sidebar');
        }
      });
  }
}
