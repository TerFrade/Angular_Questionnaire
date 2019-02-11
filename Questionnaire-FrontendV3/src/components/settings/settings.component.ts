import { Component, OnInit } from "@angular/core";
import { User } from "../../models/user";
import { UserService } from "../../services/user.service";
import { empty } from "rxjs/Observer";
import { stringify } from "@angular/core/src/util";

@Component({
  selector: "settings",
  template: require("./settings.component.html"),
  styles: [require("./settings.component.css").toString()]
})
export class SettingsComponent {
  user: User = <any>{};
  username: string;
  password: string;

  constructor(private uService: UserService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  save() {
    var request;
    if (this.username) {
      this.user.username = this.username;
    }
    if (this.password) {
      this.user.password = this.password;
    }

    if (this.user.id) {
      request = this.uService.updateUser(this.user);
      localStorage.setItem('user', JSON.stringify(this.user));
      this.username = "";
      this.password = "";
    }
  }
}
