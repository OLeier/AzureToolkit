import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';         // Delete this
import { FetchDataComponent } from './fetch-data/fetch-data.component'; // Delete this

import { SearchComponent } from './search/search.component';
//import { CommonModule } from './common/common.module';
import { GalleryComponent } from './gallery/gallery.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'search', component: SearchComponent },
  { path: 'gallery', component: GalleryComponent },
  { path: 'counter', component: CounterComponent },      // Delete this
  { path: 'fetch-data', component: FetchDataComponent }, // Delete this
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
