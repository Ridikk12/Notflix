import { Component } from '@angular/core';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent  {
	constructor(private authService: AuthenticationService, private router: Router) {

	}

	isLoggedIn() {
		return this.authService.isLoggedIn();
	}

	isAdmin() {
		return this.authService.isAdmin();
	}

	logOut() {
		this.authService.logOut().subscribe(value => {
			if (value == true)
				this.router.navigate(['authentication/login']);

		});
	}

	getUserName() {
		return this.authService.getUserName();
	}

}
