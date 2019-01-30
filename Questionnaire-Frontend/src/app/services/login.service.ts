import { User } from "./../models/user";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  usersUrl: string = "https://localhost:44334/api/users";

  constructor(private http: HttpClient) {}

  getUser(email): Observable<User> {
    return this.http.get<User>(`${this.usersUrl}/${email}`);
  }
}
