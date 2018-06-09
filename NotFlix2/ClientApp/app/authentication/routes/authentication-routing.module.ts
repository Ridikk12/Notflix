import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from './authentication.routes';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';



import { LoginComponent } from '../components/login/login.component';
import { RegisterComponent } from '../components/register/register.component';


@NgModule({
	declarations: [LoginComponent, RegisterComponent],
	imports: [
		// Router
		CommonModule,
		FormsModule,
		RouterModule.forChild(routes)
	]
})
export class AuthenticationRoutingModule { }