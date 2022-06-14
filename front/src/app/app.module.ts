import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './areas/cadastro/cadastro.component';
import { ContratacaoComponent } from './areas/contratacao/contratacao.component';
import { LoginComponent } from './areas/Login/Login.component';
import { PrincipalComponent } from './areas/principal/principal.component';
import { RelatoriosComponent } from './areas/relatorios/relatorios.component';
import { ServicosComponent } from './areas/servicos/servicos.component';
import { UsuarioComponent } from './areas/usuario/usuario.component';
import { NavbarComponent } from './shared/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    UsuarioComponent,
    CadastroComponent,
    ServicosComponent,
    ContratacaoComponent,
    RelatoriosComponent,
    LoginComponent,
    PrincipalComponent


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
