import { Question } from './../models/question';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

declare const API_URL_GLOBAL: string;

@Injectable()
export class QuestionService {
    constructor(private http: Http) { }
    create(item: Question) {
        return this.http
            .post(API_URL_GLOBAL + "questions", item)
            .toPromise()
            .then(response => {
                return <number>response.json();
            });
    }
    deleteQuestion(id) {
        return this.http.delete(API_URL_GLOBAL + 'questions/' + id).toPromise();
    }

    updateQuestion(item) {
        return this.http.put(API_URL_GLOBAL + 'questions/', item).toPromise();
    }
}
