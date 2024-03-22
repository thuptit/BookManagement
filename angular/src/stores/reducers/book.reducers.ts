import { createReducer, on } from '@ngrx/store';
import { BookModel } from '../../app/book/book.model';
import * as BookPageActions from '../actions/book.actions';

export interface BookState {
  books: BookModel[];
}

const initialBookState: BookState = {
  books: [],
};

export const bookReducer = createReducer(
  initialBookState,
  on(BookPageActions.addBook, (state, { book }) => ({
    ...state,
    books: [...state.books, book],
  })),
  on(BookPageActions.updateBook, (state, { book }) => ({
    ...state,
    books: state.books.map((item) => {
      if (item.id === book.id) {
        return { ...book };
      }
      return item;
    }),
  }))
);
