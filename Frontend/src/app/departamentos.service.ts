import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departamento } from './Departamento';
import { Pessoa } from './Pessoa';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class DepartamentosService {
  baseUrl = 'https://localhost:7088/api'
  departamentosUrl = `${this.baseUrl}/departamentos`
  pessoasUrl = `${this.baseUrl}/pessoas`

  pessoas: Pessoa[] = []

  constructor(private http: HttpClient) { }

  Select(): Observable<Departamento[]> {
    return this.http.get<Departamento[]>(this.departamentosUrl)
  }

  SelectById(idDepartamento: number): Observable<Departamento> {
    const apiUrl = `${this.departamentosUrl}/${idDepartamento}`
    return this.http.get<Departamento>(apiUrl)
  }

  Insert(departamento: Departamento): Observable<any> {
    return this.http.post<Departamento>(this.departamentosUrl, departamento, httpOptions)
  }

  Update(departamento: Departamento): Observable<any> {
    return this.http.put<Departamento>(this.departamentosUrl, departamento, httpOptions)
  }

  Delete(idDepartamento: number): Observable<any> {
    const apiUrl = `${this.departamentosUrl}/${idDepartamento}`
    return this.http.delete<number>(apiUrl, httpOptions)
  }
}
