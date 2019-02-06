import { Component } from "@angular/core";

@Component({
  selector: "profile",
  template: require("./profile.component.html"),
  styles: [require("./profile.component.css").toString()]
})
export class ProfileComponent {
  constructor() {}
}
