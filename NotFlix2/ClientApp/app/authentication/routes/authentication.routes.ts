﻿import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from '../components/login/login.component'
import { RegisterComponent } from '../components/register/register.component';

export const routes: Routes = [
	{ path: 'authentication/login', component: LoginComponent },
	{ path: 'authentication/register', component: RegisterComponent }
];