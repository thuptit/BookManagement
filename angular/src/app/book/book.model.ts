export interface BookPagingModel {
  id: number;
  name: string;
  description: string;
  categoryName: string;
}

export class BookModel {
  constructor() {
    this.id = 0;
    this.name = '';
    this.description = '';
  }
  id: number;
  name: string;
  description: string;
  categoryId?: number;
}
