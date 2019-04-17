import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { environment } from '../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private booksUrl = environment.apiUrl + environment.apiBooks;  // URL to web api

  constructor(private http: HttpClient) { }

  testApi(): Observable<any> {
    // const url = 'https://localhost:44389/api/values'; //  'http://localhost:62641/api/Books';
    const url = environment.apiUrl + environment.apiUser;
    console.log(url);
    return this.http.get<any>(url, { withCredentials: true })
    .pipe(
      tap(_ => console.log(`Api User tested ` + _)),
      catchError(this.handleError<any>('API test'))
    );
  }

  /** GET Books from the server */
  getBooks (): Observable<any[]> {
    console.log(this.booksUrl);
    return this.http.get<any[]>(this.booksUrl)
      .pipe(
        tap(_ => this.log('fetched Books')),
        catchError(this.handleError<any[]>('getBooks', []))
      );
  }

  /** GET Book by id. Return `undefined` when id not found */
  getBookNo404<Data>(id: number): Observable<any> {
    const url = `${this.booksUrl}/?id=${id}`;
    return this.http.get<any[]>(url)
      .pipe(
        map(books => books[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} Book id=${id}`);
        }),
        catchError(this.handleError<any>(`getBook id=${id}`))
      );
  }

  /** GET Book by id. Will 404 if id not found */
  getBook(id: number): Observable<any> {
    const url = `${this.booksUrl}/${id}`;
    return this.http.get<any>(url).pipe(
      tap(_ => this.log(`fetched Book id=${id}`)),
      catchError(this.handleError<any>(`getBook id=${id}`))
    );
  }

  /* GET books whose name contains search term */
  searchBooks(term: string): Observable<any[]> {
    if (!term.trim()) {
      // if not search term, return empty Book array.
      return of([]);
    }
    return this.http.get<any[]>(`${this.booksUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found Books matching "${term}"`)),
      catchError(this.handleError<any[]>('searchBooks', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new Book to the server */
  addBook (book: any): Observable<any> {
    return this.http.post<any>(this.booksUrl, book, httpOptions).pipe(
      tap((newBook: any) => this.log(`added Book w/ id=${newBook.id}`)),
      catchError(this.handleError<any>('addBook'))
    );
  }

  /** DELETE: delete the Book from the server */
  deleteBook (book: any | number): Observable<any> {
    const id = typeof book === 'number' ? book : book.id;
    const url = `${this.booksUrl}/${id}`;

    return this.http.delete<any>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Book id=${id}`)),
      catchError(this.handleError<any>('deleteBook'))
    );
  }

  /** PUT: update the Book on the server */
  updateBook (book: any): Observable<any> {
    return this.http.put(this.booksUrl, book, httpOptions).pipe(
      tap(_ => this.log(`updated Book id=${book.id}`)),
      catchError(this.handleError<any>('updateBook'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a BookService message with the MessageService */
  private log(message: string) {
    console.log(`ApiService: ${message}`);
  }

}
