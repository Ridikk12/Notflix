import { Component, Input, OnInit } from "@angular/core";
import { VideoUserService } from "../../services/videoUser.service";
import { VideoUser } from "../../models/VideoUser";
import { ActivatedRoute } from '@angular/router';

@Component({
	selector: 'video-details',
	templateUrl: './video-details.component.html',

})
export class VideoDetailsComponent implements OnInit {
	constructor(private _videoService: VideoUserService, private _route: ActivatedRoute) {

	}
	ngOnInit(): void {
		this.getVideo();
	}

	videoDetails: VideoUser = new VideoUser;

	getVideo(): void {
		const id = this._route.snapshot.paramMap.get('id');
		this._videoService.getVideoDetails(id as string).subscribe(result => {
			this.videoDetails = result;
		});

	}

	

}