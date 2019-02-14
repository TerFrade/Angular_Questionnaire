import { User } from '../models/user';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class UserService {
    constructor(private http: Http) { }

    getAllUsers() {
        return this.http.get(API_URL_GLOBAL + 'users/').toPromise().then(response => {
            return <User[]>response.json();
        });
    }

    getUser(id: number) {
        return this.http.get(API_URL_GLOBAL + 'users/' + id).toPromise().then(response => {
            return <User>response.json();
        });
    }

    updateUser(item: User) {
        return this.http.put(API_URL_GLOBAL + 'users/' + item.id, item).toPromise();
    }

    deleteUser(id: number) {
        return this.http.delete(API_URL_GLOBAL + 'users/' + id).toPromise();
    }
}
