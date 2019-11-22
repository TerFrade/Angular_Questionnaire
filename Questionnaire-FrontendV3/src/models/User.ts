import { Questionnaire } from "./Questionnaire";

export class User {
    id: number;
    username: string;
    email: string;
    password: string;
    roleId: number;
    questionnaires: Array<Questionnaire>;
} 