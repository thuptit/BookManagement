import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/enviroment';

@Injectable({
  providedIn: 'root'
})

export class BookService {
  constructor(private httpClient: HttpClient) { }

  public getAllPaging(searchText: string, pageIndex: number, pageSize: number): Observable<any> {
    const params = new HttpParams({
      fromObject: {
        searchText,
        pageIndex,
        pageSize
      }
    })
    return this.httpClient.get<any>(environment.baseUrl + '/api/book/get-all-paging', { params });
  }
}
