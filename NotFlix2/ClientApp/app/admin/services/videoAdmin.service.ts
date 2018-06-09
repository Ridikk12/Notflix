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
		//postFile(fileToUpload: File): Observable < boolean > {
		//	const endpoint = 'your-destination-url';
		//	const formData: FormData = new FormData();
		//	formData.append('fileKey', fileToUpload, fileToUpload.name);
		//	return this.httpClient
		//		.post(endpoint, formData, { headers: yourHeadersConfig })
		//		.map(() => { return true; })
		//		.catch((e) => this.handleError(e));
		//}
		var headers = new Headers();
		headers.append('Content-Type','undefined ');
		headers.set('Accept', 'application/json');

		let options = new RequestOptions({ headers: headers });

		const formData: FormData = new FormData();
		formData.append('VideoFile', uploadModel.VideoFile);
		formData.append('VideoName', uploadModel.VideoName);
		for (let i = 0; i < uploadModel.VideoGenders.length; i++) {
			formData.append('VideoGenders[' + i + '].Id', uploadModel.VideoGenders[i].id);
			formData.append('VideoGenders[' + i + '].GenderName', uploadModel.VideoGenders[i].genderName);
		}

		return this.http.post('Video/Upload', formData);
	}

	getVideoGender() {
		return this.http.get('Video/GetGenders')
			.map(result => { return result.json() });
	}


}
