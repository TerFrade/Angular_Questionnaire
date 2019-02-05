import { Component } from "@angular/core";

@Component({
  selector: "home",
  template: require("./home.component.html"),
  styles: [require("./home.component.css").toString()]
})
export class HomeComponent {
  constructor() {}
}
