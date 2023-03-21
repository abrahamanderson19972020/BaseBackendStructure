import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent implements OnInit {
  userLoggedIn: Observable<boolean> | undefined;

  constructor(public userService: UserService, private router: Router) {
    this.userLoggedIn = this.userService.isAuthenticated();
  }

  ngOnInit(): void {}
  logout() {
    this.userService.logout();
  }
}
