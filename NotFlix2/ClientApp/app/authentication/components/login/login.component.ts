import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../../shared/services/authentication.service';


@Component({
	selector: 'login',
	templateUrl: './login.template.html',
	styleUrls: ['./login.component.css']
})
export class LoginComponent {
	constructor(private http: Http, private authService: AuthenticationService, private router: Router) {

	}

	email: string = "";
	password: string = "";
	loginSucced: boolean = true;

	logIn() {
		this.authService.logIn(this.email, this.password).subscribe(result => {
			if (result == true)
				this.router.navigate(['/home']);
			else
				this.loginSucced = false;
		});
	}


}
