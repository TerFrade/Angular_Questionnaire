import { User } from './../../models/user';
import { UserService } from './../../services/user.service';
import { Component } from "@angular/core";

@Component({
   selector: "admin",
   template: require("./admin.component.html"),
   styles: [require("./admin.component.css").toString()]
})
export class AdminComponent {
   users: Array<User> = [];
   curUser: User;

   constructor(private uService: UserService) { }

   ngOnInit() {
      this.curUser = JSON.parse(localStorage.getItem('user'));
      this.uService.getAllUsers().then(item => {
         this.users = item.filter(item => item.id != this.curUser.id);
      });
   }
}
