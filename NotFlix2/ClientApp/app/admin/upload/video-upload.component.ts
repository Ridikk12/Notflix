import { Component, OnInit, ViewChild } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { VideoAdmin } from '../models/videoAdmin.model';
import { VideoAdminService } from '../services/videoAdmin.service';




@Component({
	selector: 'video-upload',
	templateUrl: './video-upload.component.html',
	providers: [VideoAdminService]
})
export class VideoUploadComponent implements OnInit {
	constructor(private videoService: VideoAdminService) {

	
	}

	@ViewChild("videoUploadForm") videoUploadForm: any;

    public model: VideoAdmin = new VideoAdmin;
	dropdownList = [];
	selectedItems = [];
	dropdownSettings = {};
	items = [];
	uploaded = false;
	

	ngOnInit() {

		this.videoService.getVideoGender().subscribe(x => {
			this.items = x;
		
		});

		this.model = new VideoAdmin();

		this.dropdownSettings = {
			singleSelection: false,
			idField: 'id',
			textField: 'genderName',
			selectAllText: 'Select All',
			unSelectAllText: 'UnSelect All',
			itemsShowLimit: 3,
			allowSearchFilter: true
		};
	}

	uploadVideo() {
		this.videoService.createNewVideo(this.model).subscribe(result => {
			this.uploaded = true;
			this.videoUploadForm.reset();
		});
	}

	onItemSelect(item: any) {
		console.log(item);
	}

	onSelectAll(items: any) {
		console.log(items);
	}

	fileEvent($event: any) {
		this.model.VideoFile = $event.target.files[0];
	}



}
