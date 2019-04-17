import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiService } from './api.service';
import { TestApiComponent } from './test-api/test-api.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BooksComponent } from './books/books.component';

@NgModule({
  declarations: [
    AppComponent,
    TestApiComponent,
    BookDetailComponent,
    BooksComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
