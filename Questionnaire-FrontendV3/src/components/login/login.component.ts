import { Component } from "@angular/core";

@Component({
  selector: "login",
  template: require("./login.component.html"),
  styles: [require("./login.component.css").toString()]
})
export class LoginComponent {
  constructor() {}
}
