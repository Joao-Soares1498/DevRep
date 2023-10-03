import { Component,ViewChild,ViewContainerRef} from '@angular/core';
import { AnualEvalComponent } from '../anual-eval/anual-eval.component';
import { TrianualEvalComponent } from '../trianual-eval/trianual-eval.component';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-new-eval',
  templateUrl: './new-eval.component.html',
  styleUrls: ['./new-eval.component.css']
})
export class NewEvalComponent  {

  check1:boolean=false;
  check2:boolean=false;

  @ViewChild('container',{read:ViewContainerRef,static:true}) container!: ViewContainerRef;

  constructor(private auth:AuthService, private router:Router){}

  //select if it is anual or trianual
  activateInterval(val :any){
    if(this.check1 == false && val == true ){
      this.check1=true;
      this.check2=false;
      this.router.navigate(['anualEval']);
    }else{
      this.check1=false;
    }


    if(this.check2 ==false && val== false ){
      this.check2=true;
      this.check1=false;
      this.container.clear();
      this.container.createComponent(TrianualEvalComponent);
    }else{
      this.check2=false;
    }
  }



}




