import { Component, Input, OnInit, Output } from "@angular/core";
import { Observable } from "rxjs/Observable";

@Component({
  selector: "navbar",
  template: require("./navbar.component.html"),
  styles: [require("./navbar.component.css").toString()]
})
export class NavbarComponent {
  @Input() isLogin: boolean;
  constructor() { }
  ngOnInit() {
    this.isLogin = JSON.parse(localStorage.getItem("isLogin"));
  }

  logout() {
    this.isLogin = !this.isLogin;
    localStorage.setItem('isLogin', JSON.stringify(this.isLogin));
    localStorage.removeItem('user');
  }
}
