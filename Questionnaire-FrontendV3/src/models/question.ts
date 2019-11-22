import { Response } from './reponse';
import { AvailableAnswer } from "./availableanswer";
export class Question {
    id: number;
    questionText: string;
    picture: string;
    index: number;
    isRequired: boolean;
    questionTypeId: number;
    questionnaireId: number;
    availableAnswers: Array<AvailableAnswer> = [];
    responses: Array<Response>;
}
