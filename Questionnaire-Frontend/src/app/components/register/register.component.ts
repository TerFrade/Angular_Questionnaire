import { FlashMessagesService } from "angular2-flash-messages";
import { ValidateService } from "./../../services/validate.service";
import { Component, OnInit } from "@angular/core";
import { RegisterService } from "src/app/services/register.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  username: string;
  email: string;
  password: string;

  constructor(
    private router: Router,
    private validateService: ValidateService,
    private flashMessage: FlashMessagesService,
    private registerService: RegisterService
  ) {}

  ngOnInit() {}

  onRegisterSubmit() {
    const user = {
      username: this.username,
      email: this.email,
      password: this.password,
      roleId: 2
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

    if (!this.registerService.addUser(user).subscribe()) {
      this.flashMessage.show("Registration Failed", {
        cssClass: "alert-danger",
        timeout: 4000
      });
    } else {
      this.flashMessage.show("Registration Complete", {
        cssClass: "alert-success",
        timeout: 4000
      });
      this.router.navigate(["/login"]);
    }
  }
}
