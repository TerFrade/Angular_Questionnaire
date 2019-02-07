import { Component, Input, OnInit } from '@angular/core';
import { Questionnaire } from '../../models/Questionnaire';

@Component({
   selector: 'questionnaire-item',
   template: require('./questionnaire-item.component.html'),
   styles: [require('./questionnaire-item.component.css').toString()],
})
export class QuestionnaireItem {
   @Input() questionnaires: Array<Questionnaire>;
   constructor() {
   }
   ngOnInit() {
   }
}
