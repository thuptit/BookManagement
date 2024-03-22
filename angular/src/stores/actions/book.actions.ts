import { createAction, props } from '@ngrx/store';
import { BookModel } from '../../app/book/book.model';

export const addBook = createAction(
  '[Book Page] Add Book',
  props<{ book: BookModel }>()
);
export const updateBook = createAction(
  '[Book Page] Update Book',
  props<{ book: BookModel }>()
);
export const getBooksPaging = createAction(
  '[Book Page] Get Book Paging',
  props<{ searchText: string; pageSize: number; pageIndex: number }>()
);
