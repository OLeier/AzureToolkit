import { Injectable } from '@angular/core';
//import { Headers, Http } from '@angular/http';  // all imports are unused
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { AzureHttpClient } from './azure-http-client';
import { BingSearchResponse } from '../models/bing-search-response';
import { ComputerVisionRequest, ComputerVisionResponse } from '../models/computer-vision-response';

@Injectable()
export class CognitiveService {
    bingSearchAPIKey = '66a85025246645d388d6fe56b6e72b43';  // TODO: config bingSearchAPIKey
    computerVisionAPIKey = '4bb3641ef9d64e0c9398cde2ed4938f7';

    constructor(private http: AzureHttpClient) { }

    searchImages(searchTerm: string): Observable<BingSearchResponse> {
        //let url = 'https://api.cognitive.microsoft.com/bing/v5.0/images/search?q=${searchTerm}';
        //let url = 'https://imagesearch3.cognitiveservices.azure.com/bing/v7.0/images/search?q=' + searchTerm;
        // The string must be surrounded with backticks (`) to indicate that it is an ES2015 template literal (https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals).
        let url = `https://imagesearch3.cognitiveservices.azure.com/bing/v7.0/images/search?q=${searchTerm}`;
        return this.http.get(url, this.bingSearchAPIKey)
            .map(response => response as BingSearchResponse)
            .catch(this.handleError);
    }

    analyzeImage(request: ComputerVisionRequest): Observable<ComputerVisionResponse> {
        //let url = 'https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Description,Tags';
        let url = 'https://imagedetection-oleier.cognitiveservices.azure.com/vision/v1.0/analyze?visualFeatures=Description,Tags';
        return this.http.post(url, this.computerVisionAPIKey, request)
            .map(response => response as ComputerVisionResponse)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
      console.error('An error occurred in CognitiveService', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
