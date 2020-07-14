import { Injectable, InjectionToken, Inject } from '@angular/core';
import { /*Headers,*/ HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ImagePostRequest } from '../models/image-post-request';
import { SavedImage } from '../models/saved-image';

@Injectable()
export class AzureToolkitService {
  private originUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') originUrl: string) {
    this.originUrl = originUrl;
    console.log('AzureToolkitService: ' + originUrl);
  }

  public saveImage(imagePostRequest: ImagePostRequest): Observable<boolean> {
    return this.http.post(`${this.originUrl}api/images`, imagePostRequest)
      .map(response => {
        //return response.ok;
        return true;
      }).catch(this.handleError);
  }

  public getImages(userId: string): Observable<SavedImage[]> {
    return this.http.get(`${this.originUrl}api/images/${userId}`)
      .map(images => {
        return images as SavedImage[];
      }).catch(this.handleError);
  }

  public searchImage(userId: string, searchTerm: string): Observable<SavedImage[]> {
    return this.http.get(`${this.originUrl}api/images/search/${userId}/${searchTerm}`)
      .map(response => {
        return response as SavedImage[];
      }).catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred in AzureToolkitService', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
