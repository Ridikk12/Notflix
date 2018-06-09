//routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from './app.route';

@NgModule({
	declarations: [],
	imports: [
		// Router
		RouterModule.forRoot(routes)
	],
	exports: [
		RouterModule
	]
})
export class RoutingModule { }