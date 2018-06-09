import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../shared/services/authentication.service';

@Component({
	selector: 'app',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})
export class AppComponent {

	isLoggedIn() {
		return this.authService.isLoggedIn();
	}

	constructor(private authService: AuthenticationService) {

	}
	
	
}
