import { Questionnaire } from '../../models/questionnaire';
import { Component, OnInit, Input } from '@angular/core';

@Component({
   selector: 'profile-item',
   template: require('./profile-item.component.html'),
   styles: [require('./profile-item.component.css').toString()],
})
export class ProfileItem {
   @Input() questionnaires: Array<Questionnaire>;
   constructor() {
   }
}
