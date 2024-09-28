import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { FormBuilder, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private formBuilder: FormBuilder = new FormBuilder();

  username = new FormControl('');
  password = new FormControl('');

  constructor(private authService: AuthService,
    private router: Router
  ) { }

  login(event: SubmitEvent) {
    event.preventDefault();
    const username = this.username.value ?? "";
    const password = this.password.value ?? "";
    this.authService.login(username, password);
  }
}
