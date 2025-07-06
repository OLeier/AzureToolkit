
// Angular CLI: 19.2.15
// import { BrowserModule } from '@angular/platform-browser';
import { APP_ID } from '@angular/core';
import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';

import { NgModule } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
//import { APP_BASE_HREF } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchComponent } from './search/search.component';

@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,   // Delete this
        FetchDataComponent, // Delete this
        GalleryComponent,
        HomeComponent,
        NavMenuComponent,
        SearchComponent
    ],
    bootstrap: [AppComponent],
    imports: [
        // Angular CLI: 19.2.15
        // BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        AppRoutingModule
    ],
    providers: [
        provideHttpClient(withInterceptorsFromDi())
    ]
})
export class AppModule { }

// https://javascript.plainenglish.io/migrating-my-newly-built-portfolio-to-angular-19-b95cb95c2aa6
// Angular CLI: 19.2.15
export const appConfig: ApplicationConfig = {
    providers: [
        { provide: APP_ID, useValue: 'ng-cli-universal' },
        provideClientHydration(),
        // ...
  ]
};
