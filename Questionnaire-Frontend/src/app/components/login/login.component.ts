import { FlashMessagesService } from "angular2-flash-messages";
import { ValidateService } from "./../../services/validate.service";
import { Component, OnInit } from "@angular/core";
import { LoginService } from "src/app/services/login.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
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
    const user = {
      email: this.email,
      password: this.password
    };
    console.log(user);
    //Required Fields
    if (!this.validateService.validateLogin(user)) {
      this.flashMessage.show("Please fill in all fields", {
        cssClass: "alert-danger",
        timeout: 4000
      });
      return false;
    }
    if (!this.validateService.validateEmail(user.email)) {
      this.flashMessage.show("Please fill in a valid email", {
        cssClass: "alert-danger",
        timeout: 4000
      });
      return false;
    }

    this.loginService.getUser(user.email).subscribe();
    this.router.navigate(["/profile"]);
  }
}
