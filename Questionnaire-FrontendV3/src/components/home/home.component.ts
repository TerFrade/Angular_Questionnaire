import { Component, OnInit } from "@angular/core";
import { QuestionnaireService } from './../../services/questionnaire.service.';
import { Questionnaire } from './../../models/questionnaire';

@Component({
  selector: "home",
  template: require("./home.component.html"),
  styles: [require("./home.component.css").toString()]
})
export class HomeComponent {
  questionnaires: Questionnaire[];
  constructor(private service: QuestionnaireService) { }

  ngOnInit() {
    this.service.getQuestionnaires().then(list => {
      this.questionnaires = list;
      this.questionnaires = this.questionnaires.filter(items => items.isPublic == true)
      localStorage.setItem('questionnaires', JSON.stringify(this.questionnaires));
    });
  }
}
