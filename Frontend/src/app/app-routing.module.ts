import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoasComponent } from './pessoas/pessoas.component';
import { DepartamentosComponent } from './departamentos/departamentos.component';

const routes: Routes = [
  { path: 'pessoas', component: PessoasComponent },
  { path: 'departamentos', component: DepartamentosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
