import { Injectable, ErrorHandler } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from './Client';

const httpheader = {
  headers: new HttpHeaders({'Content-Type' : 'application/json'})
  };
@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  private MainUrl = 'https://localhost:44365/';

  constructor(private http: HttpClient) { }
clickSearch(clientObj: Client): Observable<Client[]> {
  let SubUrl = `${this.MainUrl}EnterName/`;

  // tslint:disable-next-line: triple-equals
  if (clientObj.Firstname != undefined) {
    SubUrl = `${SubUrl}${clientObj.Firstname}/`;
  }
  // tslint:disable-next-line: triple-equals
  if (clientObj.Lastname != undefined) {
    SubUrl = `${SubUrl}${clientObj.Lastname}`;
  }
  return this.http.get<Client[]>(SubUrl, httpheader);
}

}


