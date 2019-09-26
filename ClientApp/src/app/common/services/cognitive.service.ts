import { Injectable } from '@angular/core';
//import { Headers, Http } from '@angular/http';  // all imports are unused
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { AzureHttpClient } from './azureHttpClient';
import { BingSearchResponse } from '../models/bingSearchResponse';
@Injectable()
export class CognitiveService {
    bingSearchAPIKey = '66a85025246645d388d6fe56b6e72b43';  // TODO: config bingSearchAPIKey

    constructor(private http: AzureHttpClient) { }

    searchImages(searchTerm: string): Observable<BingSearchResponse> {
        //let url = 'https://api.cognitive.microsoft.com/bing/v5.0/images/search?q=${searchTerm}';
        let url = 'https://imagesearch3.cognitiveservices.azure.com/bing/v7.0/images/search?q=' + searchTerm;
        return this.http.get(url, this.bingSearchAPIKey)
            .map(response => response as BingSearchResponse)
            .catch(this.handleError);
    }
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
