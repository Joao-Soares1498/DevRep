import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MenuComponent } from './components/menu/menu.component';
import { NewEvalComponent } from './components/new-eval/new-eval.component';
import { MyEvalComponent } from './components/my-eval/my-eval.component';
import { AnualEvalComponent } from './components/anual-eval/anual-eval.component';
import { TrianualEvalComponent } from './components/trianual-eval/trianual-eval.component';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { NgToastModule } from 'ng-angular-popup';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { SelectEvComponent } from './components/select-ev/select-ev.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    MenuComponent,
    NewEvalComponent,
    MyEvalComponent,
    AnualEvalComponent,
    TrianualEvalComponent,
    HomeComponent,
    HeaderComponent,
    SelectEvComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgToastModule,
    FormsModule,
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
