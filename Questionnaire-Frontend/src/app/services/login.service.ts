import { User } from "./../models/user";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json"
  })
};

//import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  usersUrl: string = "http://localhost:64006/api/Users";

  constructor(private http: HttpClient) {}

  //getUserByLogin(email, password) {
  // return this.http.get(
  //    `${this.usersUrl}?email=${email}&password=${password}`,
  //    httpOptions
  //  );
  //}

  async getUser(email, password) {
    return await this.http.get<User>(
      `${this.usersUrl}?email=${email}&password=${password}`
    );
  }
}
