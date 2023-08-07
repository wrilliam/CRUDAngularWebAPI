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
    pessoas!: Pessoa[]

    visivelTabela: boolean = true
    visivelFormulario: boolean = false

    constructor(private pessoasService: PessoasService) {}

    ngOnInit(): void {
      this.pessoasService.Select().subscribe(resultado => {
        this.pessoas = resultado
      })
    }

    EnviarFormulario(): void {
      const pessoa: Pessoa = this.formulario.value;

      this.pessoasService.Insert(pessoa).subscribe((resultado) => {
        this.visivelTabela = true
        this.visivelFormulario = false
        alert('Registro inserido com sucesso!')
        this.pessoasService.Select().subscribe((resultado) => {
          this.pessoas = resultado
        })
      })
    }

    ExibirFormularioCadastro(): void {
      this.visivelTabela = false;
      this.visivelFormulario = true;
      this.tituloFormulario = 'Nova Pessoa'
      this.formulario = new FormGroup({
        nome: new FormControl(null),
        apelido: new FormControl(null),
        tipo: new FormControl(null),
        documento: new FormControl(null),
        endereco: new FormControl(null)
      })
    }

    Voltar(): void {
      this.visivelTabela = true
      this.visivelFormulario = false
    }

  }
