import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }

  public getDropdownList(): Observable<any> {
    return this.httpClient.get<any>(environment.baseUrl + '/api/category/get-dropdown-list');
  }
}
