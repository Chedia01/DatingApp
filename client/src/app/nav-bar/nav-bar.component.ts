import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService, private route: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model)
      .subscribe(response => {
        this.route.navigateByUrl('/members')
      })
  }

  logout() {
    this.accountService.logout();
    this.route.navigateByUrl('/')
  }

}
