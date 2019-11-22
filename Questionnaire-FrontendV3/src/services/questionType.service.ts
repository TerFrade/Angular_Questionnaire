import { QuestionType } from './../models/questionType';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class QuestionTypeService {
  constructor(private http: Http) { }

  getQuestionTypeById(id) {
    return this.http
      .get(API_URL_GLOBAL + "questionTypes/" + id)
      .toPromise()
      .then(response => {
        return <QuestionType>response.json();
      });
  }

  getAllQuestionType() {
    return this.http
      .get(API_URL_GLOBAL + "questionTypes/")
      .toPromise()
      .then(response => {
        return <QuestionType[]>response.json();
      });
  }
}
