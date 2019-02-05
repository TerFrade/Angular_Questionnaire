import { Component } from "@angular/core";

@Component({
  selector: "register",
  template: require("./register.component.html"),
  styles: [require("./register.component.css").toString()]
})
export class RegisterComponent {
  constructor() {}

  ngOnInit() {}

  hello() {
    console.log("helloWorld");
  }
}
