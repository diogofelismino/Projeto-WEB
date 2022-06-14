import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html',
  styleUrls: ['./servicos.component.css']
})
export class ServicosComponent implements OnInit {


  public servicos: any[] = [];
  public id = null;
  public descricao = '';
  public preco = 0.0;
  public confereId =null;

  public edita: boolean=false;

  public form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(
    private api:ApiService,
    private fb: FormBuilder
    ) { }

  ngOnInit() {

    this.api.get(`servicos`).subscribe(
      (dados: any) =>{
        this.servicos = dados;
        console.table(this.servicos);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
    this.validdaForm();

  }


  public editar(item: any){



      this.id = item.id;
      this.descricao = item.descricao;
      this.preco = item.preco;
      this.confereId = item.id;



  }


  public iniciarPagina(){
    this.edita = false;
    this.api.get(`servicos`).subscribe(
      (dados: any) =>{
        this.servicos = dados;
        console.table(this.servicos);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public salvar(){

    if(this.confereId !== this.id){
      alert('Não é permitido alterar o ID');
      return;
    }

    let item = {
    id: this.id,
    descricao: this.descricao,
    preco: this.preco

    };

    this.api.post('servicos/atualizar', item).subscribe(
      (dados: any) =>{
        if(dados !== null || dados !== undefined){
          alert(`Dados do serviço ${dados.descricao} salvos com sucesso`);
          this.iniciarPagina();

        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );

  }

  public setId(item: any){
    this.id = item.id;
    this.descricao = item.descricao;

  }

  public excluir(){

    this.api.delete('servicos', this.id!).subscribe(
      (dados: any) => {
        if(dados){
          alert(`Servico: ${this.id}, removido com sucesso!`);
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }


  public validdaForm(){

    console.log()
    this.form = this.fb.group({

      id:[0],
      descricao:['', Validators.required],
      preco:['',[ Validators.required, Validators.pattern('[0-9]+([.]{0,1}([0-9])+)*')]]

    });
  }




  public criar(){



    this.api.post('servicos/inserir', this.form.value).subscribe(
      (dados: any) =>{
        if(dados !== null || dados!== undefined){
          alert(`Dados do servico ${dados.descricao} criado com sucesso`);
          this.iniciarPagina();


        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );

  }


}
