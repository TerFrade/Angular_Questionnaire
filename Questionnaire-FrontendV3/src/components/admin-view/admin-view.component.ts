import { UserService } from './../../services/user.service';
import { User } from './../../models/user';
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
   selector: 'admin-view',
   template: require('./admin-view.component.html'),
   styles: [require('./admin-view.component.css').toString()],
})
export class AdminView {
   user: User = <any>{};

   constructor(private router: Router, private route: ActivatedRoute, private uService: UserService) {
   }

   ngOnInit() {
      this.route.paramMap.subscribe(params => {
         var id = params.get('id');
         this.uService.getUser(+id).then(item => {
            this.user = item;
         });
      })

   }

   async updateUser() {
      await this.uService.updateUser(this.user);
      this.router.navigate(["admin"]);
   }
}
