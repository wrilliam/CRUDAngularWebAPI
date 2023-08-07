import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../Pessoa';
import { PessoasService } from '../pessoas.service';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.css']
})
export class PessoasComponent implements OnInit {

  formulario: any
  tituloFormulario!: string

  constructor(private pessoasService: PessoasService) {}

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

  EnviarFormulario(): void {
    const pessoa: Pessoa = this.formulario.value;

    this.pessoasService.Insert(pessoa).subscribe(resultado => {
      alert('Registro inserido com sucesso!')
    })
  }

}
