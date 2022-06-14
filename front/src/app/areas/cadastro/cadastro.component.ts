import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  public form!: FormGroup;

//  nome: string = '';
//  idade: number = 0 ;
//  cpf: string = '' ;
//  rg: string = '';
//  data_na: string = '';
//  endereco: string = '';
//  cidade: string = '';

  get f(): any{
    return this.form.controls;
  }

  constructor(
    private api:ApiService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.validdaForm();
  }

  public validdaForm(){
    this.form = this.fb.group({

      nome:['', Validators.required],
      idade:['', Validators.required],
      cpf:['', [Validators.required, Validators.minLength(11),Validators.maxLength(11)]],
      rg:['', [Validators.required,Validators.minLength(9),Validators.maxLength(9)]],
      data_nasc:['', Validators.required],
      endereco:['', Validators.required],
      cidade:['', Validators.required]

    });
  }




  public criar(){





    this.api.post('usuarios/inserir', this.form.value).subscribe(
      (dados: any) =>{
        if(dados !== null || dados !== undefined){
          alert(`Dados do usuário ${dados.nome} criado com sucesso`);


        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );

  }

}
