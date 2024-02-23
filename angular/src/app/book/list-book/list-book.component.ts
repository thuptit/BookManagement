import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookPagingModel } from '../book.model';
import { BookService } from '../../../services/book.service';

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
  pageIndex: number = 1;
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
      this.dataSource.data = response.items;
      this.totalCount = response.totalItems;
      setTimeout(() => {
        this.paginator.length = this.totalCount;
        this.paginator.pageIndex = this.pageIndex;
      });
    })
  }
  onSearch() {

  }
  onCreate(enterAnimationDuration: string, exitAnimationDuration: string) {

  }
  onChangePage(event: any) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getAllPaging();
  }
  onDelete(id: number) {

  }
}
