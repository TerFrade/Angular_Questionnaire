import { Component, Input, OnInit, Output } from "@angular/core";

@Component({
  selector: "navbar",
  template: require("./navbar.component.html"),
  styles: [require("./navbar.component.css").toString()]
})
export class NavbarComponent {
  @Input() isLogin: boolean;
  isAdmin: boolean;
  constructor() { }
  ngOnInit() {
    this.isLogin = JSON.parse(localStorage.getItem("isLogin"));
    this.isAdmin = JSON.parse(localStorage.getItem("isAdmin"));
  }

  logout() {
    this.isLogin = !this.isLogin;
    this.isAdmin = !this.isAdmin;
    localStorage.setItem('isLogin', JSON.stringify(this.isLogin));
    localStorage.setItem('isAdmin', JSON.stringify(this.isAdmin));
    localStorage.removeItem('user');
  }
}
