import { NgModule } from '@angular/core';
import { AuthGuard } from '../shared/services/authGuard.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { UserRoutingModule } from './routing/user-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VideoUserComponent } from './components/video/video.component';





@NgModule({
	declarations: [DashboardComponent, VideoUserComponent]
	,
	providers: [

	],
	imports: [
		CommonModule,
		FormsModule,
		HttpModule,
		UserRoutingModule
	]
})
export class UserModule {
}
