import { Injectable } from '@angular/core';
//import { Http, Headers } from '@angular/http';  // @deprecated use @angular/common/http instead
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AzureHttpClientService {

  constructor(private http: HttpClient) { }

  get(url: string, apiKey: string) {
      let headers = new HttpHeaders();
      headers = headers.append('Ocp-Apim-Subscription-Key', apiKey);
      return this.http.get(url, {
          headers: headers
      });
  }

  post(url: string, apiKey: string, data: any) {
      let headers = new HttpHeaders();
      headers = headers.append('Ocp-Apim-Subscription-Key', apiKey);
      return this.http.post(url, data, {
          headers: headers
      });
  }
}
