import { Router } from '@angular/router';
import { BankService } from '../../services/bank.service';
import { Component, HostListener, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginModel } from 'src/app/models/login';
import { Message, MessageService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [MessageService]
})

export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  userModel = new UserModel();
  message: Message[];

  @HostListener('window:keydown', ['$event'])
  keyEvent(e: KeyboardEvent) {
    if (e.key === '13') {
      this.login();
    }
  }

  constructor(private fb: FormBuilder,
              private userService: UserService,
              private router: Router,
              private messageService: MessageService,
              private primengConfig: PrimeNGConfig) { }

  ngOnInit(): void {
    this.formLogin = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required],
    });

    this.primengConfig.ripple = true;
  }

  login() {
    if (!this.formLogin) {
      return;
    }
    this.userModel.name = this.formLogin.get('name').value;
    this.userModel.password = this.formLogin.get('password').value;
    this.userService.signIn(this.userModel).subscribe(c => {
      this.router.navigateByUrl('/home');
    }, e => {
      this.messageService.add(
        { severity: 'error',
          summary: 'Login',
          detail: e.error.Message,
          life: 3000
        }
      );
    });
  }


}
