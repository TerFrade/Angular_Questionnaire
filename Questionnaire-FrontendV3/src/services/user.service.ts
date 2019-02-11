import { User } from '../models/user';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class UserService {
    constructor(private http: Http) { }

    updateUser(item: User) {
        return this.http.put(API_URL_GLOBAL + 'users/' + item.id, item).toPromise();
    }
}
