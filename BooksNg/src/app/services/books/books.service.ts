import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IBook } from './../../models/IBook';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  private url = 'http://localhost:5000/books';

  constructor(private http: HttpClient) { }

  get(): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.url);
  }
}
