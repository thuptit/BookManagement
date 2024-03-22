import { createFeatureSelector, createSelector } from '@ngrx/store';
import { BookState } from '../reducers/book.reducers';

export const bookFeatureKey: string = 'books';

const selectBookState = createFeatureSelector<BookState>(bookFeatureKey);

export const selectAllBook = createSelector(selectBookState, (state) => {
  console.log(state);
  return state.books;
});
