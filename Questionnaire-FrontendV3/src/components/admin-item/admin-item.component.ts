import { UserService } from './../../services/user.service';
import { User } from './../../models/user';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
   selector: 'admin-item',
   template: require('./admin-item.component.html'),
   styles: [require('./admin-item.component.css').toString()],
})
export class AdminItem {
   @Input() users: Array<User>;

   constructor(private router: Router, private uService: UserService) {
   }

   ngOnInit() {

   }

   edit(user) {
      this.router.navigate(['admin-view', user.id]);
   }

   delete(user) {
      this.uService.deleteUser(user.id);
      this.users = this.users.filter(item => item.id != user.id)
      this.router.navigate(['admin']);
   }
}
