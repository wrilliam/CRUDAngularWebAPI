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
  url = 'https://localhost:7088/api/departamentos'

  constructor(private http: HttpClient) { }

  Select(): Observable<Departamento[]> {
    return this.http.get<Departamento[]>(this.url)
  }

  SelectById(idDepartamento: number): Observable<Departamento> {
    const apiUrl = `${this.url}/${idDepartamento}`
    return this.http.get<Departamento>(apiUrl)
  }

  Insert(Departamento: Departamento): Observable<any> {
    return this.http.post<Departamento>(this.url, Departamento, httpOptions)
  }

  Update(Departamento: Departamento): Observable<any> {
    return this.http.put<Departamento>(this.url, Departamento, httpOptions)
  }

  Delete(idDepartamento: number): Observable<any> {
    const apiUrl = `${this.url}/${idDepartamento}`
    return this.http.delete<number>(apiUrl, httpOptions)
  }

  FetchPessoas(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>('https://localhost:7088/api/pessoas')
  }
}
