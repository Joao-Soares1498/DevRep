import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { MenuComponent } from './components/menu/menu.component';
import { MyEvalComponent } from './components/my-eval/my-eval.component';
import { NewEvalComponent } from './components/new-eval/new-eval.component';
import { AnualEvalComponent } from './components/anual-eval/anual-eval.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { SelectEvComponent } from './components/select-ev/select-ev.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'signup',component: SignupComponent},
  {path: 'myEval', component: MyEvalComponent, canActivate:[AuthGuard]},
  {path: 'newEval', component: NewEvalComponent, canActivate:[AuthGuard]},
  {path: 'anualEval', component: AnualEvalComponent,canActivate:[AuthGuard]},
  {path: 'menu',component:MenuComponent, canActivate:[AuthGuard]},
  {path: 'selectEv', component:SelectEvComponent, canActivate:[AuthGuard]},
  {path:"**", component: HomeComponent}//default component
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
