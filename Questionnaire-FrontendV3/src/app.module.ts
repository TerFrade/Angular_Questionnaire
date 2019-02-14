import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";

import { UserService } from './services/user.service';
import { ResponseService } from './services/response.service';
import { QuestionTypeService } from './services/questionType.service';
import { QuestionnaireService } from './services/questionnaire.service';
import { LoginService } from "./services/login.service";
import { RegisterService } from "./services/register.service";
import { QuestionService } from './services/question.service';

import { AppComponent } from "./components/app.component";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from './components/profile/profile.component';
import { ProfileItem } from './components/profile-item/profile-item.component';
import { QuestionnaireComponent } from './components/questionnaire/questionnaire.component';
import { QuestionnaireItem } from './components/questionnaire-item/questionnaire-item.component';
import { QuestionnaireView } from './components/questionnaire-view/questionnaire-view.component';
import { QuestionnaireEdit } from './components/questionnaire-edit/questionnaire-edit.component';
import { ProfileView } from './components/profile.view/profile-view.component';
import { SettingsComponent } from './components/settings/settings.component';
import { QuestionnaireCreate } from './components/questionnaire-create/questionnaire-create.component';
import { AdminComponent } from './components/admin/admin.component';
import { AdminCreate } from './components/admin-create/admin-create.component';
import { AdminItem } from './components/admin-item/admin-item.component';
import { AdminView } from './components/admin-view/admin-view.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    ProfileItem,
    QuestionnaireComponent,
    QuestionnaireItem,
    QuestionnaireView,
    QuestionnaireEdit,
    ProfileView,
    SettingsComponent,
    QuestionnaireCreate,
    AdminComponent,
    AdminItem,
    AdminCreate,
    AdminView
  ],
  providers: [RegisterService, LoginService, QuestionnaireService,
    QuestionTypeService, ResponseService, UserService, QuestionService],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "profile", component: ProfileComponent },
      { path: "questionnaires", component: QuestionnaireComponent },
      { path: 'questionnaire-view/:id/:link', component: QuestionnaireView },
      { path: 'profile-view/:id/:link', component: ProfileView },
      { path: 'settings', component: SettingsComponent },
      { path: 'questionnaire-create', component: QuestionnaireCreate },
      { path: 'questionnaire-edit/:id', component: QuestionnaireEdit },
      { path: 'admin', component: AdminComponent },
      { path: 'user-create', component: AdminCreate },
      { path: 'admin-view/:id', component: AdminView }
    ])
  ]
})
export class AppModule { }
