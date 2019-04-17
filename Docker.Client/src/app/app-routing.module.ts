import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BookDetailComponent } from './book-detail/book-detail.component';
import { BooksComponent } from './books/books.component';

const routes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'books', component: BooksComponent },
  { path: 'detail/:id', component: BookDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
