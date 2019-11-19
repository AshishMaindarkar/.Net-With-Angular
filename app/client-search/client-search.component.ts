import { Component, OnInit } from '@angular/core';
import { ClientServiceService } from '../client-service.service';
import { from } from 'rxjs';
import { Client } from '../Client';

@Component({
  selector: 'app-client-search',
  templateUrl: './client-search.component.html',
  styleUrls: ['./client-search.component.scss']
})
export class ClientSearchComponent implements OnInit {
  clientObj = new Client();
  Searchresult = [];
  constructor(private clientservice: ClientServiceService) { }

  clickSearch() {
  this.clientservice.clickSearch(this.clientObj).subscribe(
  result => {
    this.Searchresult = result;
  }
);
  }
  ngOnInit() {
  }
}
