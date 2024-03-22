import { Injectable } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as BookPageActions from '../actions/book.actions';
import { exhaustMap, map } from 'rxjs';

@Injectable()
export class BookEffects {
  constructor(private actions$: Actions, private bookService: BookService) {}

  loadBooks$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BookPageActions.getBooksPaging),
      exhaustMap((res) =>
        this.bookService
          .getAllPaging(res.searchText, res.pageIndex, res.pageSize)
          .pipe(map((result) => ({ type: '' })))
      )
    )
  );
}
