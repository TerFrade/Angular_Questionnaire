import { User } from './../../models/user';
import { QuestionnaireService } from './../../services/questionnaire.service';
import { Questionnaire } from './../../models/questionnaire';
import { Question } from './../../models/question';
import { QuestionService } from './../../services/question.service';
import { QuestionTypeService } from './../../services/questionType.service';
import { Component } from '@angular/core';
import { QuestionType } from '../../models/questionType';
import { AvailableAnswer } from '../../models/availableanswer';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
   selector: 'questionnaire-edit',
   template: require('./questionnaire-edit.component.html'),
   styles: [require('./questionnaire-edit.component.css').toString()],
})

export class QuestionnaireEdit {
   questionnaire: Questionnaire = <any>{};
   questionTypes: QuestionType[];
   questions: Array<Question> = <any>[new Question()];
   availableAnswers: Array<AvailableAnswer> = <any>[];
   user: User = <any>{};

   constructor(private qtService: QuestionTypeService, private qService: QuestionnaireService, private questService: QuestionService, private router: Router, private route: ActivatedRoute) {
   }

   ngOnInit() {
      this.user = JSON.parse(localStorage.getItem('user'));
      this.qtService.getAllQuestionType().then(list => {
         this.questionTypes = list;
      })
      this.questions[0].questionTypeId = 0;
      this.route.paramMap.subscribe(params => {
         var id = params.get('id');
         this.qService.getQuestionnairesById(+id).then(item => {
            this.questionnaire = item;
         });
      })
   }

   addAnswer(index: number) {
      this.questionnaire.questions[index].availableAnswers.push(new AvailableAnswer());
   }

   removeAnswer(index: number, id: number) {
      this.questionnaire.questions[index].availableAnswers.splice(id, 1);
   }

   addQuestion() {
      this.questions.push(new Question())
      var index = this.questions.length - 1;
      this.questions[index].questionTypeId = 0;
      this.questionnaire.questions.push(this.questions[index]);
   }

   removeQuestion(index: number) {
      this.questService.deleteQuestion(this.questionnaire.questions[index].id);
      this.questionnaire.questions.splice(index, 1);
   }

   moveQuestionUp(index: number) {
      if (this.questionnaire.questions.length > 1 && index != 0) {
         let cur = this.questionnaire.questions[index - 1];
         this.questionnaire.questions[index - 1] = this.questionnaire.questions[index];
         this.questionnaire.questions[index] = cur;
      }
   }

   moveQuestionDown(index: number) {
      if (this.questionnaire.questions.length > 1 && index != this.questionnaire.questions.length - 1) {
         let cur = this.questionnaire.questions[index + 1];
         this.questionnaire.questions[index + 1] = this.questionnaire.questions[index];
         this.questionnaire.questions[index] = cur;
      }
   }

   async editQuestionnaire() {
      this.questions.forEach(element => {
         element.questionnaireId = this.questionnaire.id;
         this.questService.create(element);
      });
      await this.qService.updateQuestionniare(this.questionnaire);

      this.router.navigate(['profile']);
   }

}
