import { Injectable, Inject } from '@angular/core';
import { /*Headers,*/ HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
//import 'rxjs/add/operator/catch';
//import 'rxjs/add/operator/map';
import { catchError, map, tap } from 'rxjs/operators';

import { ImagePostRequest } from '../models/image-post-request';
import { SavedImage } from '../models/saved-image';

@Injectable({
  providedIn: 'root'
})
export class AzureToolkitService {
  private originUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') originUrl: string) {
    this.originUrl = originUrl;
    console.log('AzureToolkitService: ' + originUrl);
  }

  public saveImage(imagePostRequest: ImagePostRequest): Observable<boolean> {
    return this.http.post(`${this.originUrl}api/images`, imagePostRequest).pipe(
      map(response => {
        //return response.ok;
        return true;
      }),
      catchError(this.handleError<boolean>('saveImage'))
    );
  }

  public getImages(userId: string): Observable<SavedImage[]> {
    return this.http.get(`${this.originUrl}api/images/${userId}`).pipe(
      map(images => {
        return images as SavedImage[];
      }),
      catchError(this.handleError<SavedImage[]>('getImages'))
    );
  }

  public searchImage(userId: string, searchTerm: string): Observable<SavedImage[]> {
    return this.http.get(`${this.originUrl}api/images/search/${userId}/${searchTerm}`).pipe(
      map(response => {
        return response as SavedImage[];
      }),
      catchError(this.handleError<SavedImage[]>('searchImage'))
    );
  }

  /*
  private handleError(error: any): Promise<any> {
    console.error('An error occurred in AzureToolkitService', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
  */

  /*
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
