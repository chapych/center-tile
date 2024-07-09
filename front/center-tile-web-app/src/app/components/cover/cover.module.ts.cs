import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AngularYandexMapsModule } from 'angular8-yandex-maps';

import { CoverComponent } from './app.component';

@NgModule({
  imports:      [BrowserModule, FormsModule, AngularYandexMapsModule ],
  declarations: [ CoverComponent ],
  bootstrap:    [ CoverComponent ]
})
export class CoverModule { }
