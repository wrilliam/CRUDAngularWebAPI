import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PessoasService } from './pessoas.service';
import { PessoasComponent } from './pessoas/pessoas.component';
import { DepartamentosService } from './departamentos.service';
import { DepartamentosComponent } from './departamentos/departamentos.component';

@NgModule({
  declarations: [
    AppComponent,
    PessoasComponent,
    DepartamentosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [HttpClientModule, PessoasService, DepartamentosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
