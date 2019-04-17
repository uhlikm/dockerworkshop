import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ApiService }  from '../api.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  @Input() book: any;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService,
    private location: Location
  ) {}

  ngOnInit() {
    this.getBook();
  }

  getBook(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.apiService.getBook(id)
      .subscribe(book => this.book = book);
  }

  goBack(): void {
    this.location.back();
  }

 save(): void {
    this.apiService.updateBook(this.book)
      .subscribe(() => this.goBack());
  }
}
