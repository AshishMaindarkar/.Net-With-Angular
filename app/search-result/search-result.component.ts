import { Component, OnInit, Input } from '@angular/core';
import { ClientServiceService } from '../client-service.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {
@Input() Searchresult;
  constructor( ) { }


  ngOnInit() {
  }

}
