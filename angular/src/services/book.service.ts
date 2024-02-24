import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of, startWith } from 'rxjs';
import { environment } from '../environments/enviroment';
import { BookModel } from '../app/book/book.model';

@Injectable({
  providedIn: 'root'
})

export class BookService {
  private readonly baseUrl = environment.baseUrl + '/api/book';
  constructor(private httpClient: HttpClient) { }

  public getAllPaging(searchText: string, pageIndex: number, pageSize: number): Observable<any> {
    const params = new HttpParams({
      fromObject: {
        searchText,
        pageIndex,
        pageSize
      }
    });
    return this.httpClient.get<any>(this.baseUrl + '/get-all-paging', { params });
  }

  public getBook(id: number): Observable<any> {
    return this.httpClient.get<any>(this.baseUrl + `/${id}`);
  }

  public create(book: BookModel): Observable<any> {
    return this.httpClient.post<any>(this.baseUrl, book);
  }

  public update(book: BookModel): Observable<any> {
    return this.httpClient.put<any>(this.baseUrl, book)
      .pipe((startWith({ isSaving: true })),
        catchError(err => of(false)));
  }

  public delete(id: number): Observable<any> {
    return this.httpClient.delete<any>(this.baseUrl + `/${id}`);
  }
}
