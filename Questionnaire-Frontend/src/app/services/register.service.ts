import { User } from "./../models/user";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json"
  })
};

@Injectable({
  providedIn: "root"
})
export class RegisterService {
  usersUrl: string = "http://localhost:64006/api/Users/";

  constructor(private http: HttpClient) {}

  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.usersUrl, user, httpOptions);
  }
}
