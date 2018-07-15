import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { VideoUser } from '../models/VideoUser';

@Injectable()
export class VideoUserService {
	constructor(private http: Http) {

	}

	getAvailableVideo() {
		return this.http.get('Video/GetUserVideos').map(
			x => x.json() as Array<VideoUser>);
	}

	getVideoDetails(videoId: AAGUID) {
		return this.http.get('Video/GetVideoDetails?videoId=' + videoId)
			.map(
				(x: any) => x.json() as VideoUser);

	}

}
