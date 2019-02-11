import { Response } from '../models/reponse';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class ResponseService {
  constructor(private http: Http) { }

  postResponse(item: Response) {
    return this.http.post(API_URL_GLOBAL + 'responses', item).toPromise().then(response => {
      return <number>response.json();
    });
  }
}
