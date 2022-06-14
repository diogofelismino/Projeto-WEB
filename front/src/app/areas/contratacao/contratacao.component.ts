import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-contratacao',
  templateUrl: './contratacao.component.html',
  styleUrls: ['./contratacao.component.css']
})
export class ContratacaoComponent implements OnInit {



  public retorno: any = [];
  public servico: any = []; // retorna os serviços
  public envio: any = [];

  public idd: number = 0;

  public cpf = '';
  public des = '';

  public verifica: boolean = false;


  constructor(
    private api:ApiService
  ) { }

  ngOnInit() {

    this.carregaServico();
  }

  public carregaServico(){

    this.api.get(`contratacao/servicos`).subscribe({
      next: dados => {
        this.servico = dados;

      },
      error: erro => alert(erro.error)

    })

  }


  public buscaCpf(){
    this.api.get(`contratacao/${this.cpf}`).subscribe({
      next: dados => {
          this.retorno = dados;
          const v = this.retorno.find((e: any) => e.descricao == 'VAZIO');
          this.verifica = (v?.descricao == 'VAZIO') ? true : false;
          console.table(this.retorno);
          console.table(this.verifica);
      },
      error: erro => alert(erro.error)
    })


  }


  public iniciarPagina(){

    this.api.get(`servicos`).subscribe(
      (dados: any) =>{
        this.servico = dados;
        console.table(this.servico);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public insereServico(id: number){

    let serv = this.envio.find((s: any) => s.id_servico == id);
    if (serv?.id_servico == id) {
      let i = this.envio.findIndex((s: any) => s.id_servico == serv.id_servico);
      this.envio.splice(i, 1);
      return;
    }
    this.envio.push({
      id_servico: id,
      cpf_usuario: this.cpf
    });
  }

  public contrataServico(){
    if(this.envio.length == 0){
      alert('Selecione ao menos um serviço');
      return;
    }

    this.api.post(`contratacao`, this.envio).subscribe(
      () => {
        alert('Serviços contratados');
        this.carregaServico();
      },
      (erro: any) => {
        alert(erro.error);
      },
      () => {
        this.buscaCpf();
        this.envio = [];

      }


    )

  }

  public recebe(id: number, des: any){
      this.idd = id;
      this.des = des
  }

  public remove(){
    this.api.deleteId('contratacao',this.idd).subscribe(
      (dados: any) => {
        if(dados){
          alert(`Contrato: removido com sucesso!`);
          this.carregaServico();
          this.buscaCpf();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }



}
