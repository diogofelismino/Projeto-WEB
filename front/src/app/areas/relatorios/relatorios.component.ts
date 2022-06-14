import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.component.html',
  styleUrls: ['./relatorios.component.css']
})
export class RelatoriosComponent implements OnInit {

  public id_servico = 0;
  public descricao = '';
  public assinante = 0;
  public valor = 0.0;
  public faturamento = 0.0;

  public relatorios: any = [];
  public retorno: any =[];
  public verifica: boolean = false;
  public verificaIn: boolean = false;

  public ver = 0;

  public cpf = '';


  constructor(private api:ApiService) { }

  ngOnInit() {

    this.iniciarPagina();
  }

  public corrigePreco() {
    this.relatorios.forEach((item: any, index: number) => {
    this.relatorios[index].PRECO = parseFloat(item.PRECO).toFixed(2);
    });
    }



  public pegarRe(){
    this.relatorios = [];
    this.api.get(`relatorios/inadimplentes`).subscribe(
      (dados: any) =>{
        this.relatorios = dados;
        this.corrigePreco();
        console.table(this.relatorios);

      },
      (erro: any) => {
        alert(erro.error);
      }
    )
    console.table();


  }

  public pegarCPf(){
    this.relatorios = [];
    this.api.get(`relatorios/inadimplentes/${this.cpf}`).subscribe(
      (dados: any) =>{
        this.relatorios = dados;
        this.corrigePreco();
        console.table(this.relatorios);

      },
      (erro: any) => {
        alert(erro.error);
      }
    )
    console.table();


  }

  public iniciarPagina(){

    this.api.get(`relatorios/faturamento`).subscribe(
      (dados: any) =>{
        this.relatorios = dados;
        console.table(this.relatorios);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
    console.table();
  }


 public verif(){

  if(this.ver == 1){
    this.verifica = true;
    this.verificaIn = false;


    this.iniciarPagina();

  }

  if(this.ver == 2){
    this.verifica = false;
    this.verificaIn = true;
    this.pegarRe();





  }

 }

}
