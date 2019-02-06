import { User } from "./../models/User";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class LoginService {
  constructor(private http: Http) {}
  getByEmailPassword(email: string, password: string) {
    return this.http
      .get(API_URL_GLOBAL + "users?email=" + email + "&password=" + password)
      .toPromise()
      .then(response => {
        return <User>response.json();
      });
  }
}
