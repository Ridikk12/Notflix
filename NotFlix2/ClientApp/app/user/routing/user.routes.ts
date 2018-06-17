import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from '../components/dashboard/dashboard.component';


export const routes: Routes = [
	{ path: 'dashboard', component: DashboardComponent },
	//{ path: 'authentication/register', component: "" }
];