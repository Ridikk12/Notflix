import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app/app.component';
import { AppModuleShared } from './app.shared.module';


@NgModule({
	bootstrap: [AppComponent],
    imports: [
		BrowserModule,
		AppModuleShared
	],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
