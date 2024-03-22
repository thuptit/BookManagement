import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routes';
import {
  NbLayoutModule,
  NbMenuModule,
  NbSidebarModule,
  NbThemeModule,
} from '@nebular/theme';
import { AppHeaderComponent } from '../components/app-header/app-header.component';
import { AppMenuBarComponent } from '../components/app-menu-bar/app-menu-bar.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { stores } from './app.stores';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    AppRoutingModule,
    NbThemeModule.forRoot({ name: 'light' }),
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbLayoutModule,
    AppHeaderComponent,
    AppMenuBarComponent,
    NbEvaIconsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    StoreModule.forRoot({ ...stores }),
    EffectsModule.forRoot([]),
  ],
  bootstrap: [AppComponent],
  providers: [],
})
export class AppModule {}
