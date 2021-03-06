﻿import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

import { AuthenticationService } from './authentication.service'
@Injectable()
export class AdminGuard implements CanActivate {

	constructor(private router: Router, private authService: AuthenticationService) { }

	canActivate() {
		return this.authService.isAdmin();
	}
}