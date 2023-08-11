import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { Departamento } from '../Departamento';
import { DepartamentosService } from '../departamentos.service';
import { Pessoa } from '../Pessoa';
import { PessoasService } from '../pessoas.service';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})
export class DepartamentosComponent implements OnInit {
  formulario: any
  tituloFormulario!: string
  departamento: Departamento = new Departamento()
  departamentos!: Departamento[]
  idDepartamento!: number
  pessoas: Pessoa[] = []

  visivelTabela: boolean = true
  visivelFormulario: boolean = false

  constructor(private departamentosService: DepartamentosService, private pessoasService: PessoasService) {}

  ngOnInit(): void {
    this.departamentosService.Select().subscribe(resultado => {
      this.departamentos = resultado
    })

    this.FetchPessoas()
  }

  EnviarFormulario(): void {
    const departamento: Departamento = this.formulario.value;

    if(departamento.idDepartamento > 0) {
      this.departamentosService.Update(departamento).subscribe(() => {
        this.visivelTabela = true
        this.visivelFormulario = false
        alert('Registro atualizado com sucesso!')
        this.departamentosService.Select().subscribe(resultado => {
          this.departamentos = resultado
        })
      })
    }
    else {
      this.departamentosService.Insert(departamento).subscribe(() => {
        this.visivelTabela = true
        this.visivelFormulario = false
        alert('Registro inserido com sucesso!')
        this.departamentosService.Select().subscribe(resultado => {
          this.departamentos = resultado
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
      idResponsavel: new FormControl(null)
    })
  }

  Voltar(): void {
    this.visivelTabela = true
    this.visivelFormulario = false
  }

  ExibirFormularioAtualizacao(idDepartamento: number): void {
    this.visivelTabela = false;
    this.visivelFormulario = true;

    this.departamentosService.SelectById(idDepartamento).subscribe(resultado => {
      this.tituloFormulario = `Atualizando Registro de ${resultado.nome}`
      this.formulario = new FormGroup({
        idDepartamento: new FormControl(resultado.idDepartamento),
        nome: new FormControl(resultado.nome),
        idResponsavel: new FormControl(resultado.idResponsavel)
      })
    })
  }

  ExcluirRegistro(idDepartamento: number): void {
    this.departamentosService.Delete(idDepartamento).subscribe(() => {
      alert("Registro excluído com sucesso!")
      this.departamentosService.Select().subscribe(resultado => {
        this.departamentos = resultado
      })
    })
  }

  FetchPessoas(): void {
    this.pessoasService.Select().subscribe(
      pessoas => {
        this.pessoas = pessoas
      },
      erro => {
        console.error('Ocorreu um erro ao resgatar a lista de pessoas', erro)
      }
    )
  }

}
