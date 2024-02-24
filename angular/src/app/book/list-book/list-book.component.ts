import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookPagingModel } from '../book.model';
import { BookService } from '../../../services/book.service';
import { CreateOrEditBookComponent } from '../create-or-edit-book/create-or-edit-book.component';
import { DeleteBookComponent } from '../delete-book/delete-book.component';

@Component({
  selector: 'app-list-book',
  templateUrl: './list-book.component.html',
  styleUrl: './list-book.component.scss'
})
export class ListBookComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'description', 'categoryName', 'action'];
  dataSource = new MatTableDataSource<BookPagingModel>();
  totalCount: number = 0;
  searchText: string = '';
  isLoading: boolean = false;
  @ViewChild(MatPaginator) paginator = {} as MatPaginator;
  pageIndex: number = 0;
  pageSize: number = 20;
  constructor(public dialog: MatDialog, private _bookService: BookService) {
  }

  ngOnInit(): void {
    this.getAllPaging();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getAllPaging() {
    this._bookService.getAllPaging(this.searchText, this.pageIndex, this.pageSize).subscribe(response => {
      this.dataSource.data = response.result.items;
      this.totalCount = response.result.totalItems;
      setTimeout(() => {
        this.paginator.length = this.totalCount;
        this.paginator.pageIndex = this.pageIndex;
      });
    })
  }
  onSearch() {
    this.getAllPaging();
  }
  onCreate(enterAnimationDuration: string, exitAnimationDuration: string) {
    const modalCreate = this.dialog.open(CreateOrEditBookComponent, {
      autoFocus: true,
      width: '700px',
      enterAnimationDuration,
      exitAnimationDuration,
      data: {
        bookId: 0
      }
    });
    modalCreate.afterClosed().subscribe((result) => {
      this.getAllPaging();
    });
  }
  onEdit(bookId: number, enterAnimationDuration: string, exitAnimationDuration: string) {
    const modalCreate = this.dialog.open(CreateOrEditBookComponent, {
      autoFocus: true,
      width: '700px',
      enterAnimationDuration,
      exitAnimationDuration,
      data: {
        bookId
      }
    });
    modalCreate.afterClosed().subscribe((result) => {
      this.getAllPaging();
    });
  }
  onChangePage(event: any) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getAllPaging();
  }
  onDelete(book: BookPagingModel) {
    const dialog = this.dialog.open(DeleteBookComponent, {
      width: '250px',
      enterAnimationDuration: '500ms',
      exitAnimationDuration: '300ms',
      data: book
    });
    dialog.afterClosed().subscribe(() => this.getAllPaging());
  }
}
