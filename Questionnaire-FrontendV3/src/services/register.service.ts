import { User } from "../models/user";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class RegisterService {
  constructor(private http: Http) { }
  create(item: User) {
    return this.http
      .post(API_URL_GLOBAL + "users", item)
      .toPromise()
      .then(response => {
        return <number>response.json();
      });
  }
}
