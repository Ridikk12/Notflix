
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { RoutingModule } from './routing/routing.module.ts';

import { AuthenticationModule } from './authentication/authentication.module';
import { AuthGuard } from './shared/services/authGuard.service';
import { AuthenticationService } from './shared/services/authentication.service';

import { AdminModule } from './admin/admin.module';
import { UserModule } from './user/user.module';



@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent
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
		UserModule,
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
