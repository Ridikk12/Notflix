import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VideoUploadComponent } from '../upload/video-upload.component';

export const routes: Routes = [
	{ path: 'admin/upload', component: VideoUploadComponent },
	//{ path: 'authentication/register', component: "" }
];