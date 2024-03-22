import { bookReducer } from '../stores/reducers/book.reducers';
import { bookFeatureKey } from '../stores/selectors/book.selectors';

export const stores = {
  [bookFeatureKey]: bookReducer,
};
