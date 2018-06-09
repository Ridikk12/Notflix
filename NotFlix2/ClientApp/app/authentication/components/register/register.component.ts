import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { RegisterModel } from './model/register.model';


@Component({
	selector: 'register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.css'],
	providers: [RegisterModel]
})
export class RegisterComponent {
	constructor(private http: Http, private model: RegisterModel, private router: Router) {
	
	}
	registerSucced: boolean = true;

	register() {
		this.http.post('Account/Register', { Email: this.model.Email, Password: this.model.Password }).subscribe(result => {
			let resultJson = result.json();
			this.registerSucced = resultJson.registerSucced;
			if (this.registerSucced == true) {
				this.router.navigate(['/authentication/login']);

			}
		}, error => console.error(error));
	}

}

