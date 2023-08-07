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
    idPessoa!: number;

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

      if(pessoa.idPessoa > 0) {
        this.pessoasService.Update(pessoa).subscribe((resultado) => {
          this.visivelTabela = true
          this.visivelFormulario = false
          alert('Registro atualizado com sucesso!')
          this.pessoasService.Select().subscribe((resultado) => {
            this.pessoas = resultado
          })
        })
      }
      else {
        this.pessoasService.Insert(pessoa).subscribe((resultado) => {
          this.visivelTabela = true
          this.visivelFormulario = false
          alert('Registro inserido com sucesso!')
          this.pessoasService.Select().subscribe((resultado) => {
            this.pessoas = resultado
          })
        })
      }
    }

    ExibirFormularioCadastro(): void {
      this.visivelTabela = false;
      this.visivelFormulario = true;
      this.tituloFormulario = 'Novo Registro'
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

    ExibirFormularioAtualizacao(idPessoa: number): void {
      this.visivelTabela = false;
      this.visivelFormulario = true;

      this.pessoasService.SelectById(idPessoa).subscribe((resultado) => {
        this.tituloFormulario = `Atualizando Registro de ${resultado.nome}, aka ${resultado.apelido}`
        this.formulario = new FormGroup({
          idPessoa: new FormControl(resultado.idPessoa),
          nome: new FormControl(resultado.nome),
          apelido: new FormControl(resultado.apelido),
          tipo: new FormControl(resultado.tipo),
          documento: new FormControl(resultado.documento),
          endereco: new FormControl(resultado.endereco)
        })
      })
    }

  }
