import { QuestionnaireService } from './../../services/questionnaire.service';
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
   constructor(private router: Router, private qService: QuestionnaireService) {
   }

   view(questionnaire) {
      this.router.navigate(['/profile-view', questionnaire.id, questionnaire.link]);
   }

   edit(questionnaire) {
      this.router.navigate(['/questionnaire-edit', questionnaire.id]);
   }
   editPublish(questionnaire) {
      questionnaire.isPublic = !questionnaire.isPublic;
      this.qService.updateQuestionniare(questionnaire);
   }

   delete(questionnaire) {
      this.qService.deleteQuestionnaire(questionnaire.id);
      this.questionnaires = this.questionnaires.filter(item => item.id != questionnaire.id)
      this.router.navigate(['profile']);
   }
}
