import { Questionnaire } from './../models/questionnaire';
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
}
