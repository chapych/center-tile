import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CoverComponent } from "./components/cover/cover.component";
import {DropDownComponent} from "./components/drop-down/drop-down.component";
import {CoverInfoComponent} from "./components/cover-info/cover-info.component";
import {HeaderComponent} from "./components/header/header.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CoverComponent, DropDownComponent, CoverInfoComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'center-tile-web-app';
}
