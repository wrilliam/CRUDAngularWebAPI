import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from './Pessoa';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  baseUrl = 'https://localhost:7088/api'
  pessoasUrl = `${this.baseUrl}/pessoas`

  constructor(private http: HttpClient) { }

  Select(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.pessoasUrl)
  }

  SelectById(idPessoa: number): Observable<Pessoa> {
    const apiUrl = `${this.pessoasUrl}/${idPessoa}`
    return this.http.get<Pessoa>(apiUrl)
  }

  Insert(pessoa: Pessoa): Observable<any> {
    return this.http.post<Pessoa>(this.pessoasUrl, pessoa, httpOptions)
  }

  Update(pessoa: Pessoa): Observable<any> {
    return this.http.put<Pessoa>(this.pessoasUrl, pessoa, httpOptions)
  }

  Delete(idPessoa: number): Observable<any> {
    const apiUrl = `${this.pessoasUrl}/${idPessoa}`
    return this.http.delete<number>(apiUrl, httpOptions)
  }
}
