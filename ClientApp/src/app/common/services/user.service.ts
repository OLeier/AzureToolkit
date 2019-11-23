import { Injectable, /*InjectionToken, */Inject } from '@angular/core';
//import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { User, AADUser } from '../models/user';

@Injectable()
export class UserService {

  private originUrl: string;
  private aadUser: AADUser;
  //private http: HttpClient;

  constructor(private http: HttpClient, @Inject('BASE_URL') originUrl: string) {
    this.originUrl = originUrl;
    console.log('UserService: ' + originUrl);
  }

  public getUser(): Observable<User> {
    return this.http.get(`${this.originUrl}.auth/me`)
      .map(response => {

        try {
          this.aadUser = response[0] as AADUser;

          let user = new User();
          user.userId = this.aadUser.user_id;

          this.aadUser.user_claims.forEach(claim => {
            switch (claim.typ) {
              case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname":
                user.firstName = claim.val;
                break;
              case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname":
                user.lastName = claim.val;
                break;
            }
          });
          return user;
        }
        catch (Exception) {
          console.log(`UserService.getUser-Error: ${Exception}`);
        }
      }).catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred in UserService', error); // for demo purposes only
    //return Promise.reject(error.message || error);

    let user = new User();
    user.userId = "{2AB43DD1-88AC-48E8-B37A-50C45D28CCFA}";
    user.firstName = "fn";
    user.lastName = "ln";
    return Promise.resolve(user);
  }
}
