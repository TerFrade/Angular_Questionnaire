import { User } from './../../models/user';
import { QuestionnaireService } from './../../services/questionnaire.service';
import { Questionnaire } from './../../models/questionnaire';
import { Question } from './../../models/question';
import { QuestionService } from './../../services/question.service';
import { QuestionTypeService } from './../../services/questionType.service';
import { Component } from '@angular/core';
import { QuestionType } from '../../models/questionType';
import { AvailableAnswer } from '../../models/availableanswer';
import { Router } from '@angular/router';

@Component({
   selector: 'questionnaire-create',
   template: require('./questionnaire-create.component.html'),
   styles: [require('./questionnaire-create.component.css').toString()],
})

export class QuestionnaireCreate {
   questionnaire: Questionnaire = <any>{};
   questionTypes: QuestionType[];
   questions: Array<Question> = <any>[new Question()];
   availableAnswers: Array<AvailableAnswer> = <any>[];
   user: User = <any>{};

   constructor(private router: Router, private qtService: QuestionTypeService, private qService: QuestionnaireService, private questService: QuestionService) {
   }

   ngOnInit() {
      this.user = JSON.parse(localStorage.getItem('user'));
      this.qtService.getAllQuestionType().then(list => {
         this.questionTypes = list;
      })
      this.questions[0].questionTypeId = 0;
   }

   addAnswer(index: number) {
      this.questions[index].availableAnswers.push(new AvailableAnswer());
   }

   removeAnswer(index: number, id: number) {
      this.questions[index].availableAnswers.splice(id, 1);
   }

   addQuestion() {
      this.questions.push(new Question())
      var index = this.questions.length - 1;
      this.questions[index].questionTypeId = 0;
   }

   removeQuestion(index: number) {
      this.questions.splice(index, 1);
   }

   moveQuestionUp(index: number) {
      if (this.questions.length > 1 && index != 0) {
         let cur = this.questions[index - 1];
         this.questions[index - 1] = this.questions[index];
         this.questions[index] = cur;
         debugger;
      }
   }

   moveQuestionDown(index: number) {
      if (this.questions.length > 1 && index != this.questions.length - 1) {
         let cur = this.questions[index + 1];
         this.questions[index + 1] = this.questions[index];
         this.questions[index] = cur;
      }
   }

   async addQuestionnaire() {
      //this.questionnaire.questions = this.questions;
      this.questionnaire.isPublic = false;
      this.questionnaire.userId = this.user.id;
      let questionnaireId = await this.qService.postQuestionaire(this.questionnaire);
      this.questions.forEach(element => {
         element.questionnaireId = questionnaireId;
         debugger;
         this.questService.create(element);
      });
      this.router.navigate(['profile']);
   }

}
