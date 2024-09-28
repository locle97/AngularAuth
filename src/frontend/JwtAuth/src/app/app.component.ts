import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './auth.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf],
  providers: [AuthService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'JwtAuth';
  isLoggedIn = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
      this.isLoggedIn = this.authService.isAuthenticate();
  }

  logout() {
    this.isLoggedIn = false;
    this.authService.logout();
  }
}
