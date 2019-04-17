import { Component, OnInit } from '@angular/core';

import { ApiService }  from '../api.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: any[];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks(): void {
    this.apiService.getBooks()
    .subscribe(books => this.books = books);
  }

  add(name: string, author: string): void {
    name = name.trim();
    if (!name) { return; }
    author = author.trim();
    if (!author) { return; }

    const book = { 'name': name, 'author': author };
    this.apiService.addBook(book as any)
      .subscribe(book => {
        this.books.push(book);
      });
  }

  delete(book: any): void {
    this.books = this.books.filter(h => h !== book);
    this.apiService.deleteBook(book).subscribe();
  }
}
