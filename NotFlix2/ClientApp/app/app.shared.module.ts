
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { RoutingModule } from './routing/routing.module.ts';

import { AuthenticationModule } from './authentication/authentication.module';
import { AuthGuard } from './shared/services/authGuard.service';
import { AuthenticationService } from './shared/services/authentication.service';

import { AdminModule } from './admin/admin.module';



@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		HomeComponent
	],
	providers: [
		AuthenticationService,
		AuthGuard,

	],
    imports: [
        CommonModule,
        HttpModule,
		FormsModule,
		AuthenticationModule,
		AdminModule,
		RoutingModule,
	],
	exports: [
		CommonModule,
		FormsModule,
	],
	bootstrap: [AppComponent]
})
export class AppModuleShared {
}
