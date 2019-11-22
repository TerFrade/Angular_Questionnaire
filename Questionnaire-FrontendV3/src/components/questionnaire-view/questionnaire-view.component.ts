import { Response } from './../../models/reponse';
import { ResponseService } from '../../services/response.service';
import { QuestionTypeService } from './../../services/questionType.service';
import { Component, } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Questionnaire } from '../../models/questionnaire';
import { QuestionnaireService } from '../../services/questionnaire.service';
import { NgForm } from '@angular/forms';


@Component({
   selector: 'questionnaire-view',
   template: require('./questionnaire-view.component.html'),
   styles: [require('./questionnaire-view.component.css').toString()],
})
export class QuestionnaireView {
   questionnaire: Questionnaire = <any>{};
   responses: Array<Response> = <any>[];
   response: Response = <any>{};
   //questionType: Array<QuestionType> = new Array<QuestionType>();
   //availableAnswer: AvailableAnswer = <any>{};

   constructor(private router: Router, private route: ActivatedRoute,
      private service: QuestionnaireService, private qtService: QuestionTypeService, private rService: ResponseService) {
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

   save(f: NgForm) {
      this.questionnaire.questions.forEach(item => {
         this.response = new Response();
         this.response.responseText = f.value[item.id.toString()]
         this.response.questionId = item.id
         this.rService.postResponse(this.response);
         //this.responses.push(this.response);
         this.router.navigate(["questionnaires"]);
      });

      console.log(this.responses);

   }
}
