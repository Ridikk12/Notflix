import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { VideoAdmin } from '../models/videoAdmin.model';


@Injectable()
export class VideoAdminService {
	constructor(private http: Http) {

	}

	createNewVideo(uploadModel: VideoAdmin) {
		const formData: FormData = this.prepareFormData(uploadModel);
		return this.http.post('Video/Upload', formData);
	}

	private prepareFormData(uploadModel: VideoAdmin) {

		const formData: FormData = new FormData();

		formData.append('VideoFile', uploadModel.VideoFile);
		formData.append('VideoName', uploadModel.VideoName);

		for (let i = 0; i < uploadModel.VideoGenders.length; i++) {
			formData.append('VideoGenders[' + i + '].Id', uploadModel.VideoGenders[i].id);
			formData.append('VideoGenders[' + i + '].GenderName', uploadModel.VideoGenders[i].genderName);
		}

		return formData;
	}

	getVideoGender() {
		return this.http.get('Video/GetGenders')
			.map(result => { return result.json() });
	}

}
