import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-test-api',
  templateUrl: './test-api.component.html',
  styleUrls: ['./test-api.component.css']
})
export class TestApiComponent implements OnInit {

  response : any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  callService() {
    this.apiService.testApi().subscribe(response => (this.response = response));
  }
}
