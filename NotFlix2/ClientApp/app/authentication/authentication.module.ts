import { NgModule } from '@angular/core';
import { AuthGuard } from '../shared/services/authGuard.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';



import { AuthenticationRoutingModule } from './routes/authentication-routing.module';

@NgModule({
	providers: [
	],
	imports: [
		CommonModule,
		FormsModule,
		HttpModule,
		AuthenticationRoutingModule
	]
})
export class AuthenticationModule {
}
