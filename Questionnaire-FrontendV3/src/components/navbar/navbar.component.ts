import { Component } from "@angular/core";

@Component({
  selector: "navbar",
  template: require("./navbar.component.html"),
  styles: [require("./navbar.component.css").toString()]
})
export class NavbarComponent {
  constructor() {}
}
