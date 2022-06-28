import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from './models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseUrl='https://localhost:7160/api/'

  constructor(private http:HttpClient) { }

  getAllBooks(){
    return this.http.get<Book[]>(this.baseUrl+'books')
  }

  addBook(book:Book){
    return this.http.post(this.baseUrl+'books',book)
  }
}
