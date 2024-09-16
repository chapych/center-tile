import { Injectable } from '@angular/core';
import { DataSuggestion } from '../../models/datasuggestion';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SERVER_URL } from '../../utils/constants';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataSuggestionsService {
  private url = SERVER_URL + "/suggestions";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : SERVER_URL })
  };
  constructor( private http : HttpClient) { }

  public add(dataSuggestion : DataSuggestion){
    return this.http.post<DataSuggestion>(this.url, dataSuggestion, this.httpOptions).subscribe(
      data => console.log('success', data),
      error => console.log('oops', error)
    );
  }
}
