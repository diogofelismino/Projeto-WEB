import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-contratacao',
  templateUrl: './contratacao.component.html',
  styleUrls: ['./contratacao.component.css']
})
export class ContratacaoComponent implements OnInit {

  public cpf = '';

  public retorno: any = [];
  public servicos: any = [];
  public servicosCheck: any =[];
  public envio: any = [];

  public verifica: boolean = false;

  constructor(
    private api: ApiService
  ) { }

  ngOnInit() {
    this.carregaServicos();
  }

  public reset() {
    this.retorno = [];
    this.servicosCheck = [];
    this.envio = [];
    this.validaCheck();
    if (this.cpf !== '')
      this.buscaCpf();
  }

  validaCheck() {
    this.servicos.forEach((servico: any) => {
      servico.check = false;
      this.servicosCheck.push(servico);
    });
    console.table(this.servicosCheck);
  }

  public carregaServicos() {
    this.api.get('contratacao/servicos').subscribe({
      next: dados => {
        this.servicos = dados;
        this.validaCheck();
      },
      error: erro => alert(erro.error)
    })
  }

  public buscaCpf() {
    this.api.get(`contratacao/${this.cpf}`).subscribe({
      next: dados => {
        this.retorno = dados;
        const v = this.retorno.find((e: any) => e.descricao == 'VAZIO');
        this.verifica = (v?.descricao == 'VAZIO') ? true : false;
        console.table(this.retorno);
        console.log(this.verifica);
      },
      error: erro => alert(erro.error)
    })
  }

  public insereServico(item: any) {
    item.check = !item.check;
  }

  public contrataServico() {
    this.servicosCheck.forEach((servico: any) => {
      if(servico.check) {
        this.envio.push({
          id_servico: servico.id,
          cpf_usuario: this.cpf
        });
      }
    })

    if (this.envio.length == 0) {
      alert('Selecione ao menos um serviço');
      return;
    }
    this.api.post('contratacao', this.envio).subscribe(
      (dados: any) => {
        alert('Serviços contratados')
      },
      (erro: any) => {
        alert(erro.error);
      },
      () => {
        this.reset();
      }
    )
  }

}
