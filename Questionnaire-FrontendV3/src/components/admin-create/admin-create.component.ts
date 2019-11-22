import { RegisterService } from './../../services/register.service';
import { Component } from '@angular/core';
import { User } from '../../models/user';
import { Router } from "@angular/router";

@Component({
   selector: 'admin-create',
   template: require('./admin-create.component.html'),
   styles: [require('./admin-create.component.css').toString()],
})
export class AdminCreate {
   user: User = <any>{};
   constructor(private register: RegisterService, private router: Router) {
   }

   ngOnInit() {
      this.user.roleId = 0;
   }

   createUser() {
      if (this.user.roleId == 0)
         this.user.roleId = 2;
      this.register.create(this.user).then(
         () => {
            this.router.navigate(["/admin"]);
         })
   }
}
