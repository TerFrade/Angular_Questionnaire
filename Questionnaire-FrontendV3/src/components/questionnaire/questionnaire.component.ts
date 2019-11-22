import { QuestionnaireService } from '../../services/questionnaire.service';
import { Questionnaire } from './../../models/questionnaire';
import { Component } from '@angular/core';

@Component({
   selector: 'questionnaire',
   template: require('./questionnaire.component.html'),
   styles: [require('./questionnaire.component.css').toString()],
})
export class QuestionnaireComponent {
   questionnaires: Array<Questionnaire>;
   constructor() {

   }
   ngOnInit() {
      this.questionnaires = JSON.parse(localStorage.getItem('questionnaires'));
   }
}
