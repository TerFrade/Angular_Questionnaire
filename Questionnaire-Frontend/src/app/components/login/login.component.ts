import { User } from "./../../models/user";
import { FlashMessagesService } from "angular2-flash-messages";
import { ValidateService } from "./../../services/validate.service";
import { Component, OnInit } from "@angular/core";
import { LoginService } from "src/app/services/login.service";
import { Router } from "@angular/router";
import { EmailValidator } from "@angular/forms";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  user: User;
  email: string;
  password: string;

  constructor(
    private router: Router,
    private validateService: ValidateService,
    private flashMessage: FlashMessagesService,
    private loginService: LoginService
  ) {}

  ngOnInit() {}

  onLoginSubmit() {
    //Required Fields
    console.log(this.user);
    if (!this.validateService.validateLogin(this.email, this.password)) {
      this.flashMessage.show("Please fill in all fields", {
        cssClass: "alert-danger",
        timeout: 4000
      });
      return false;
    }
    if (!this.validateService.validateEmail(this.email)) {
      this.flashMessage.show("Please fill in a valid email", {
        cssClass: "alert-danger",
        timeout: 4000
      });
      return false;
    }

    // this.loginService
    //   .getUserByLogin(this.email, this.password)
    //  .subscribe(res => {
    //     this.user = <User>res;
    //   });

    //this.loginService.getUser(this.email, this.password).then(res => {
    // return res.subscribe(x => {
    //    this.user = x;
    // });
    //});

    this.loginService.getUser(this.email, this.password).then(res => {
      return res.subscribe(x => {
        this.user = x;
      });
    });

    //this.loginService
    // .getUser(this.email, this.password)
    //  .subscribe((User: any) => {
    //    if (User) {
    //      this.user = User;
    //    }
    //  });

    console.log(this.user);
    if (this.user == null) {
      this.flashMessage.show("Login Failed", {
        cssClass: "alert-danger",
        timeout: 4000
      });
    } else {
      this.flashMessage.show("Welcome", {
        cssClass: "alert-success",
        timeout: 4000
      });
      console.log(this.user);
      localStorage.setItem("user", JSON.stringify(this.user));
      this.router.navigate(["/profile"]);
    }
  }
}
