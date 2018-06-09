import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/services/authGuard.service';

import { HomeComponent } from '../components/home/home.component';

export const routes: Routes = [
	{ path: '', redirectTo: 'home', pathMatch: 'full', canActivate: [AuthGuard] },
	{ path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
	{ path: '**', redirectTo: 'home', canActivate: [AuthGuard]  }
];