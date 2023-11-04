import { Component,ElementRef,OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { DocxService } from 'src/app/services/docx.service';
import { EvsService } from 'src/app/services/evs.service';
import { ExcelService } from 'src/app/services/excel.service';
import { PdfService } from 'src/app/services/pdf.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-anual-eval',
  templateUrl: './anual-eval.component.html',
  styleUrls: ['./anual-eval.component.css']
})
export class AnualEvalComponent implements OnInit{

  //modal declaration
  @ViewChild("myModal") myModal!: ElementRef<HTMLDivElement>;

  //tab mechanics
  openTab(tabName:string):void{
    const tabcontent = document.getElementsByClassName('tabcontent') as HTMLCollectionOf<HTMLElement>;
    for(let i=0;i<tabcontent.length;i++){
      tabcontent[i].style.display='none';
    }

    const tablinks = document.getElementsByClassName('tablinks') as HTMLCollectionOf<HTMLElement>;
    for(let i=0; i<tablinks.length;i++){
      tablinks[i].className = tablinks[i].className.replace('active','');
    }

    const selectedTab = document.getElementById(tabName) as HTMLElement;
    if (selectedTab) {
      selectedTab.style.display = 'block';
    }
    const clickedButton = event?.target as HTMLElement;
    if (clickedButton) {
      clickedButton.className += ' active';
    }

  }

  constructor(private fb:FormBuilder,
    private excelService: ExcelService,
    private toast:NgToastService,
    private router: Router,
    private auth: AuthService,
    private userStore: UserStoreService,
    private pdfService: PdfService,
    private docxService: DocxService,
    private evService:EvsService,
    ){}

  //from for the excel doc
  excelAnualForm!: FormGroup;
  public Id:number = 0;
  public nameid:string= "";

  ngOnInit(): void{
    //get user nameid
    this.userStore.getIdFromStore()
    .subscribe(val=>{
      const nameidFromToken = this.auth.getIdFromToken();
      this.nameid = val || nameidFromToken;
    });


    //excel group form structure
    this.excelAnualForm = this.fb.group({
      Id:[Number(localStorage.getItem("EvId")), Validators.required],
      nameid:[this.nameid,Validators.required],
      fileName:['',Validators.required],
      state:[false,Validators.required],
      F3G3:[2017,Validators.required],
      K4K4 :[40,Validators.required],
      L4L4 :[35,Validators.required],
      M4M4 :[25,Validators.required],
      L8L10 :['[0,0,0]',Validators.required],
      L11L11 :[0,Validators.required],
      L12L12 :[0,Validators.required],
      L13L13 :[0,Validators.required],
      L14L14 :[0,Validators.required],
      L15L15 :[0,Validators.required],
      L16L16 :[0,Validators.required],
      L17L17 :[0,Validators.required],
      L18L18 :[0,Validators.required],
      L19L19 :[0,Validators.required],
      L20L20 :[0,Validators.required],
      L21L21 :[0,Validators.required],
      L22L22 :[0,Validators.required],
      L23L23 :[0,Validators.required],
      L24L24 :[0,Validators.required],
      L25L25 :[0,Validators.required],
      L26L26 :[0,Validators.required],
      L27L27 :[0,Validators.required],
      L28L28 :[0,Validators.required],
      L29L29 :[0,Validators.required],
      L30L30 :[0,Validators.required],
      L31L31 :[0,Validators.required],
      L32L32 :[0,Validators.required],
      L33L33 :[0,Validators.required],
      L34L34 :[0,Validators.required],
      L35L35 :[0,Validators.required],
      L36L36 :[0,Validators.required],
      L37L37 :[0,Validators.required],
      L38L38 :[0,Validators.required],
      L39L39 :[0,Validators.required],
      L40L40 :[0,Validators.required],
      L41L41 :[0,Validators.required],
      L42L42 :[0,Validators.required],
      L43L43 :[0,Validators.required],
      L44L44 :[0,Validators.required],
      L45L45 :[0,Validators.required],
      L47L47 :[0,Validators.required],
      L48L48 :[0,Validators.required],
      L49L49 :[0,Validators.required],
      L50L50 :[0,Validators.required],
      L51L51 :[0,Validators.required],
      L52L52 :[0,Validators.required],
      L53L53 :[0,Validators.required],
      L54L54 :[0,Validators.required],
      L55L55 :[0,Validators.required],
      L56L56 :[0,Validators.required],
      L57L57 :[0,Validators.required],
      L58L58 :[0,Validators.required],
      L59L59 :[0,Validators.required],
      L60L60 :[0,Validators.required],
      L64L64 :[0,Validators.required],
      L65L65 :[0,Validators.required],
      L66L66 :[0,Validators.required],
      L67L67 :[0,Validators.required],
      L68L68 :[0,Validators.required],
      L69L69 :[0,Validators.required],
      L70L70 :[0,Validators.required],
      L71L71 :[0,Validators.required],
      L72L72 :[0,Validators.required],
      L73L73 :[0,Validators.required],
      L74L74 :[0,Validators.required],
      L75L75 :[0,Validators.required],
      L76L76 :[0,Validators.required],
      L77L77 :[0,Validators.required],
      L78L78 :[0,Validators.required],
      L79L79 :[0,Validators.required],
      L80L80 :[0,Validators.required],
      L81L81 :[0,Validators.required],
      L82L82 :[0,Validators.required],
      L83L83 :[0,Validators.required],
      L84L84 :[0,Validators.required],
      L85L85 :[0,Validators.required],
      L86L86 :[0,Validators.required],
      L87L87 :[0,Validators.required],
      L88L88 :[0,Validators.required],
      L89L89 :[0,Validators.required],
      L90L90 :[0,Validators.required],
      L91L91 :[0,Validators.required],
    });

    if(localStorage.getItem("EvId") !== null){
      const evId = Number(localStorage.getItem("EvId"));
      console.log("On load->" + evId);
      console.log(typeof evId);
      this.evService.getEvData(evId)
      .subscribe((evData:any) =>{
        this.Id = evId;
        this.excelAnualForm.patchValue(evData);
      });

    }

  }

  //save ev to later finish
  saveEval(){

    if(this.excelAnualForm.valid){
      this.evService.postEvs(this.excelAnualForm.value)
      .subscribe({
        next:(res=>{
          this.toast.success({detail:"Sucesso!", summary:res.message,duration:5000});
          localStorage.removeItem("EvId");
          this.router.navigate(['menu']);
        }),
        error:(err=>{
          this.toast.error({detail:"Erro",summary:"Ocorreu um erro a guardar",duration:3000});
        })
      })
    }else{
      this.toast.error({detail:"Erro",summary:"Formato do documento inválido verifique se o cabeçalho está devidamente preenchido", duration:5000});
    }

  }

  //submit excel
  submitEval(){
    //if the form is valid
    if(this.excelAnualForm.valid){
      //calls excel service
      this.excelService.excel(this.excelAnualForm.value)
      .subscribe({
        next:(res=>{
          //alert(res.message)
          this.toast.success({detail:"Sucesso!", summary:res.message,duration:5000});
          localStorage.removeItem("EvId");
          this.openModal();
        }),
        error:(err=>{
          this.toast.error({detail:"Erro", summary:"Ocorreu algum erro a submeter",duration:5000});
        })
      })
    }else{
      this.toast.error({detail:"Erro",summary:"Formato do documento inválido verifique se o cabeçalho está devidamente preenchido", duration:5000});
    }


  }


  //opens modal
  openModal(){
    this.myModal.nativeElement.style.display="block";
  }

  //closes modal
  closeModal(){
    this.myModal.nativeElement.style.display="none";
    this.router.navigate(['menu']);
  }

  //generates the pdf with the excel info
  generatePdf(){
    //if form valid
    if(this.excelAnualForm.valid){
      //calls service to generate the pdf
      this.pdfService.pdf(this.excelAnualForm.value)
      .subscribe({
        next:(res=>{
          this.toast.success({detail:"Sucesso",summary:res.message,duration:5000});
          this.closeModal();
        }),
        error:(err=>{
          this.toast.error({detail:"Erro",summary:"Ocorreu algum erro",duration:5000});
        })
      })
    }else{
      this.toast.error({detail:"Erro",summary:"Formato do documento inválido verifique se o cabeçalho está devidamente preenchido",duration:5000});
    }
  }

  //generates Anexo I
  generateDocx(){
    //if form valid
    if(this.excelAnualForm.valid){
      //calls service responsible to add the docx to user files
      this.docxService.docx(this.excelAnualForm.value)
      .subscribe({
        next:(res=>{
          this.toast.success({detail:"Sucesso",summary:res.message,duration:5000});
          this.closeModal();
        }),
        error:(err => {
          this.toast.error({detail:"Erro",summary:err.message,duration:5000});
        })
      })
    }else{
      this.toast.error({detail:"Erro",summary:"Formato do documento inválido verifique se o cabeçalho está devidamente preenchido",duration:5000});
    }
  }

  //button call to generate both pdf and docx
  generatePdfAndDoxc(){
    this.generatePdf();
    this.generateDocx();
  }

  //checks the sum of the percentages associated to the evaluation
  //could not sum - had to check all patterns
  sum(){
    const k4 = this.excelAnualForm.controls['K4K4'].value;
    const l4 = this.excelAnualForm.controls['L4L4'].value;
    const m4 = this.excelAnualForm.controls['M4M4'].value;

    if(k4==35 && l4==35 && m4==30
      || k4==35 && l4==40 && m4==25
      || k4==35 && l4==35 && m4==30

      || k4==40 && l4==30 && m4==30
      || k4==40 && l4==35 && m4==25
      || k4==40 && l4==40 && m4==20

      || k4==45 && l4==30 && m4==25
      || k4==45 && l4==35 && m4==20
){
      return false;
    }else{

      return true;
    }

  }

}
