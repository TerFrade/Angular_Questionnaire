import { QuestionTypeService } from './../../services/questionType.service';
import { AvailableAnswer } from './../../models/availableanswer';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Questionnaire } from '../../models/questionnaire';
import { QuestionnaireService } from '../../services/questionnaire.service';
import { QuestionType } from './../../models/questionType';

@Component({
   selector: 'profile-view',
   template: require('./profile-view.component.html'),
   styles: [require('./profile-view.component.css').toString()],
})
export class ProfileView {
   questionnaire: Questionnaire = <any>{};
   //questionType: Array<QuestionType> = new Array<QuestionType>();
   //availableAnswer: AvailableAnswer = <any>{};

   constructor(private router: Router, private route: ActivatedRoute, private service: QuestionnaireService, private qtService: QuestionTypeService) {
   }

   ngOnInit() {
      this.route.paramMap.subscribe(params => {
         var id = params.get('id');
         this.service.getQuestionnairesById(+id).then(item => {
            this.questionnaire = item;

            // this.questionnaire.questions.forEach(element => {
            //    this.qtService.getQuestionTypeById(element.questionTypeId).then(item => {
            //       this.questionType.push(item);
            //       console.log(this.questionType);
            //    });
            // });
         });
      })

   }
}
