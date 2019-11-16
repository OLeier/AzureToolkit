import { Injectable, InjectionToken, Inject } from '@angular/core';
import { /*Headers,*/ HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ImagePostRequest } from '../models/imagePostRequest';

@Injectable()
export class AzureToolkitService {
    private originUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL')originUrl: string) {
        this.originUrl = originUrl;
    }

    public saveImage(imagePostRequest: ImagePostRequest): Observable<boolean> {
        return this.http.post(`${this.originUrl}/api/images`, imagePostRequest)
            .map(response => {
                //return response.ok;
                return true;
            }).catch(this.handleError);
    }
    
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}