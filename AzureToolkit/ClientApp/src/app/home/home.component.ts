import { Component, OnInit, VERSION } from '@angular/core';
import { UserService } from '../common/services/user.service';
import { User } from '../common/models/user';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    standalone: false
})
export class HomeComponent implements OnInit {

  user: User;
  angularVersion = VERSION.full;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    // throw new Error("Method not implemented.");
    this.userService.getUser().subscribe(user => this.user = user );
  }

}
