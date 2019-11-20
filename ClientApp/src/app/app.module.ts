import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';         // Delete this
import { FetchDataComponent } from './fetch-data/fetch-data.component'; // Delete this

import { SearchComponent } from './search/search.component';
import { CommonModule } from './common/common.module';
import { GalleryComponent } from './gallery/gallery.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,   // Delete this
    FetchDataComponent, // Delete this
    SearchComponent,
    GalleryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'search', component: SearchComponent },
      { path: 'gallery', component: GalleryComponent },
      { path: 'counter', component: CounterComponent },      // Delete this
      { path: 'fetch-data', component: FetchDataComponent }, // Delete this
    ]),
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
