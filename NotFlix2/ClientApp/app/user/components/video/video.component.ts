import { Component, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { VideoUserService } from '../../services/videoUser.service'
import { VideoUser } from '../../models/VideoUser';

@Component({
	selector: 'video-user',
	templateUrl: './video.component.html',
	providers: [VideoUserService]
})
export class VideoUserComponent {
	constructor(private _videoService: VideoUserService) {
		
	}

	@Input()
	videoModel: VideoUser = new VideoUser;

}
