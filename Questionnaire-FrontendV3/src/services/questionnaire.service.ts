import { Questionnaire } from '../models/questionnaire';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class QuestionnaireService {
  constructor(private http: Http) { }

  getQuestionnaires() {
    return this.http
      .get(API_URL_GLOBAL + "questionnaires")
      .toPromise()
      .then(response => {
        return <Questionnaire[]>response.json();
      });
  }

  getQuestionnairesById(id) {
    return this.http
      .get(API_URL_GLOBAL + "questionnaires/" + id)
      .toPromise()
      .then(response => {
        return <Questionnaire>response.json();
      });
  }

  postQuestionaire(item: Questionnaire) {
    return this.http.post(API_URL_GLOBAL + 'questionnaires', item).toPromise().then(response => {
      return <number>response.json();
    });
  }

  deleteQuestionnaire(id) {
    return this.http.delete(API_URL_GLOBAL + 'questionnaires/' + id).toPromise();
  }

  updateQuestionniare(item) {
    return this.http.put(API_URL_GLOBAL + 'questionnaires/' + item.id, item).toPromise();
  }
}
