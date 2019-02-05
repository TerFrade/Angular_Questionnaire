import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { AppComponent } from './components/app.component';

@NgModule({
   bootstrap: [AppComponent],
   declarations: [
      AppComponent,
   ],
   providers: [
   ],
   imports: [
      BrowserModule,
      HttpModule,
      FormsModule
   ]
})
export class AppModule {
}
