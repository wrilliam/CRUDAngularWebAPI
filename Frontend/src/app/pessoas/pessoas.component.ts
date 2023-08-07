import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  formulario: any
  tituloFormulario!: string

  constructor() {}

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Pessoa'
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      apelido: new FormControl(null),
      tipo: new FormControl(null),
      documento: new FormControl(null),
      endereco: new FormControl(null)
    })
  }

}
