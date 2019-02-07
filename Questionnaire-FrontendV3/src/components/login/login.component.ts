import { LoginService } from "./../../services/login.service";
import { User } from "../../models/user";
import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { EmailValidator } from "@angular/forms";
import { stringify } from "querystring";

@Component({
  selector: "login",
  template: require("./login.component.html"),
  styles: [require("./login.component.css").toString()]
})
export class LoginComponent {
  item: User = <any>{};
  isLogin: boolean = false;

  constructor(private service: LoginService, private router: Router) { }

  login() {
    this.service.getByEmailPassword(this.item.email, this.item.password).then(
      item => {
        this.item = item;
        this.isLogin = true;
        localStorage.setItem("user", JSON.stringify(this.item));
        localStorage.setItem("isLogin", JSON.stringify(this.isLogin));
        this.router.navigate(["/profile"]);
      },
      error => {
        this.isLogin = false;
        alert(error.toString());
      }
    );
  }
}
