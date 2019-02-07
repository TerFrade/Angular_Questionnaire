import { User } from '../../models/user';
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "profile",
  template: require("./profile.component.html"),
  styles: [require("./profile.component.css").toString()]
})
export class ProfileComponent {
  user: User;
  constructor() { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'));
  }
}
