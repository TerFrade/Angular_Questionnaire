import { User } from "./../../models/User";
import { RegisterService } from "./../../services/register.service";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "register",
  template: require("./register.component.html"),
  styles: [require("./register.component.css").toString()]
})
export class RegisterComponent {
  item: User = <any>{};
  busy: boolean;
  constructor(private service: RegisterService, private router: Router) {}

  ngOnInit() {
    this.item.roleId = 2;
  }

  register() {
    var request;
    this.busy = true;
    request = this.service.create(this.item);
    request.then(
      () => {
        this.router.navigate(["/login"]);
      },
      error => {
        this.busy = false;
        alert(error.toString());
      }
    );
  }
}
