import { Component, OnInit, HostListener } from '@angular/core';
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

	@HostListener("window:onbeforeunload", ["$event"])
	clearLocalStorage(event: any) {
		localStorage.clear();
	}


	constructor(private authService: AuthenticationService) {
	}
	
	
}
