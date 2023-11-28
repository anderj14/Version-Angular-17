import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { User } from './shared/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Client';

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadCurrentUser();
  }


  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if (token) {
      this.accountService.loadCurrentUser(token).subscribe(
        (user: User | null) => {
          // Handle the user data if needed
          console.log('User loaded:', user);
        },
        (error: Error) => {
          // Handle errors if needed
          console.error('Error loading user:', error);
        }
      );
    }
  }
}
