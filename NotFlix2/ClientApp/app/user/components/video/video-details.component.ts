import { Component, Input } from "@angular/core";

@Component({
	selector: 'video-details',
	templateUrl: './video-details.component.html',
})
export class VideoDetailsComponent {

	@Input()
	videoId: string = "";

}