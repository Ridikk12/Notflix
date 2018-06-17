import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { VideoUserService } from '../../services/videoUser.service'
import { VideoUser } from '../../models/VideoUser';
import { VideoUserComponent } from '../video/video.component';

@Component({
	selector: 'dashboard',
	templateUrl: './dashboard.component.html',
	providers: [VideoUserService]
})
export class DashboardComponent {
	constructor(private _videoService: VideoUserService) {
		this.getVideos();
	}

	videos: Array<VideoUser> = [];


	getVideos() {
		this._videoService.getAvailableVideo().subscribe(result => {
			console.log(result);
			this.videos = result;
		});
	}


}
