import { Question } from './question';
export class Questionnaire {
    id: number;
    title: string;
    description: string;
    isPublic: boolean;
    link: string;
    questions: Array<Question>;
}