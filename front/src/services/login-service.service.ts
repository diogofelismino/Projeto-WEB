import { Injectable } from '@angular/core';
import { elementAt } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

constructor() { }

public ver: boolean = false;

salvaUsuarioLogado (user: any) {
  sessionStorage.setItem('usuariologado', user.nome);
  sessionStorage.setItem('cpflogado', user.cpf);
}

usuarioLogado(): any {
  return sessionStorage.getItem('usuariologado');
}

cpfLogado(): any {
  return sessionStorage.getItem('cpflogado');
}

limpaUsuario() {
  sessionStorage.clear();
}

autenticado() {
  if(this.usuarioLogado() === null)
    return false;
  return true;
}



}
