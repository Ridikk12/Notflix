import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { VideoDetailsComponent } from '../components/video/video-details.component';
import { AuthGuard } from '../../shared/services/authGuard.service';


export const routes: Routes = [
	{ path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]  },
	{ path: 'video-details/:id', component: VideoDetailsComponent, canActivate: [AuthGuard]  }
];