import { Component, Input, OnInit } from '@angular/core';
import { Questionnaire } from '../../models/Questionnaire';
import { Router } from '@angular/router';

@Component({
   selector: 'questionnaire-item',
   template: require('./questionnaire-item.component.html'),
   styles: [require('./questionnaire-item.component.css').toString()],
})
export class QuestionnaireItem {
   @Input() questionnaires: Array<Questionnaire>;

   constructor(private router: Router) {
   }

   view(questionnaire) {
      this.router.navigate(['/questionnaire-view', questionnaire.id, questionnaire.link]);
   }
}
