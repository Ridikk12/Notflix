import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';



@Injectable()
export class AuthenticationService {
	constructor(private http: Http) {

	}

	logIn(email: string, password: string) {
		return this.http.post('Account/Login', { Email: email, Password: password }).map(result => {
			var resultJson = result.json();
			if (resultJson == true) {
				localStorage.setItem('currentUser', resultJson);
			}
			return resultJson;
	
		});

			
	}

	logOut(): Observable<any>  {
		return new Observable(observer  => {
			if (typeof window !== 'undefined') {	
				localStorage.removeItem('currentUser');
				observer.next(true);
			}
			observer.next(false);
	
		});
	}

	isLoggedIn() {
		if (typeof window !== 'undefined' && localStorage.getItem("currentUser") ) {
			return true; 
		}
		return false;
	}


}