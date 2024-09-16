import { Component } from '@angular/core';
import {NgOptimizedImage} from "@angular/common";
import {MatAnchor, MatButton} from "@angular/material/button";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    NgOptimizedImage,
    MatButton,
    MatAnchor
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

}
