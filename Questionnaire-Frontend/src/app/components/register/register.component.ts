import {
  FlashMessagesModule,
  FlashMessagesService
} from "angular2-flash-messages";
import { ValidateService } from "./../../services/validate.service";
import { Component, OnInit } from "@angular/core";
import { ChildActivationStart } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  username: String;
  email: String;
  password: String;

  constructor(
    private validateService: ValidateService,
    private flashMessage: FlashMessagesService
  ) {}

  ngOnInit() {}

  onRegisterSubmit() {
    const user = {
      username: this.username,
      email: this.email,
      password: this.password
    };
    //Required Fields
    if (!this.validateService.validateRegister(user)) {
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
  }
}
