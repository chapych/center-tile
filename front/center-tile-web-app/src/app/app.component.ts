import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CoverComponent } from "./components/cover/cover.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CoverComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'center-tile-web-app';
}
