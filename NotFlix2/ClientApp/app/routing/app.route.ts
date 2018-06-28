import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/services/authGuard.service';

export const routes: Routes = [
	{ path: '', redirectTo: 'dashboard', pathMatch: 'full', canActivate: [AuthGuard] },
	{ path: '**', redirectTo: 'dashboard', canActivate: [AuthGuard]  }
];