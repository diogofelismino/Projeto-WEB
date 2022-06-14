import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { LoginServiceService } from 'src/services/login-service.service';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {


  public form!: FormGroup;


  get f(): any{
    return this.form.controls;
  }

  public cpf: string = '';
  public hash_senha: string = '';

  public ver: boolean = true;
  public cadastro: boolean = false;
  constructor(private api: ApiService,
    private fb: FormBuilder,
    private router: Router,
    private login: LoginServiceService
    ) { }

  ngOnInit() {

    this.validdaForm();


    this.ver = !this.login.autenticado();

  }

  public validdaForm(){
    this.form = this.fb.group({

      nome: ['', Validators.required],
      cpf:['', [Validators.required, Validators.minLength(11),Validators.maxLength(11)]],
      hash_senha:['', [Validators.required,  Validators.minLength(6)]],



    });

  }


  public logar(){

    this.api.post('login', this.form.value).subscribe(
      (dados: any) =>{
        if(dados !== null || dados !== undefined){
          alert('logado com sucesso');


          this.ver = false;
          this.login.salvaUsuarioLogado(this.form.value);
          this.router.navigate(['/principal']);


        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );
    console.log(this.form.value)

  }



public mudar(){
  this.cadastro = true;

}

public registrar(){


  this.api.post('cadastro', this.form.value).subscribe(
    (dados: any) =>{
      if(dados !== null || dados !== undefined){
        alert('Cadastrado com sucesso');


        this.login.salvaUsuarioLogado(dados);
        this.router.navigate(['/principal']);
        this.ver = true;
        this.cadastro = false;
        console.log(this.login.salvaUsuarioLogado)

      }
    },
    (erro: any) => {
      alert(erro.error);
    }
  );
  console.log(this.form.value)

}

public mudarV(){
  this.cadastro = false;
}


}
