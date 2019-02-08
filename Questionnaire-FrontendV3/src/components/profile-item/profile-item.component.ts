import { Questionnaire } from '../../models/questionnaire';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
   selector: 'profile-item',
   template: require('./profile-item.component.html'),
   styles: [require('./profile-item.component.css').toString()],
})
export class ProfileItem {
   @Input() questionnaires: Array<Questionnaire>;
   constructor(private router: Router) {
   }

   view(questionnaire) {
      this.router.navigate(['/profile-view', questionnaire.id]);
   }
}
