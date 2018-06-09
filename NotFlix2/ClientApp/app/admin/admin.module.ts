import { NgModule } from '@angular/core';
import { AuthGuard } from '../shared/services/authGuard.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './routes/admin-routing.module';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { VideoUploadComponent } from './upload/video-upload.component';
import { VideoAdmin } from './models/videoAdmin.model';




@NgModule({
	declarations: [VideoUploadComponent]
	,
	providers: [VideoAdmin

	],
	imports: [
		CommonModule,
		FormsModule,
		HttpModule,
		AdminRoutingModule,
		NgMultiSelectDropDownModule.forRoot()

		
	]
})
export class AdminModule {
}
