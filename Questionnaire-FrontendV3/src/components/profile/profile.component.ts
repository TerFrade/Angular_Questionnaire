import { QuestionnaireService } from './../../services/questionnaire.service';
import { Questionnaire } from './../../models/questionnaire';
import { User } from '../../models/user';
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "profile",
  template: require("./profile.component.html"),
  styles: [require("./profile.component.css").toString()]
})
export class ProfileComponent {
  questionnaires: Array<Questionnaire> = <any>[];
  user: User;
  constructor(private qService: QuestionnaireService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'));
    this.qService.getQuestionnaires().then(items => {
      this.questionnaires = items.filter(x => x.userId == this.user.id);
    })

  }
}
