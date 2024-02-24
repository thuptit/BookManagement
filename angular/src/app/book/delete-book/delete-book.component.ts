import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BookService } from '../../../services/book.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrl: './delete-book.component.scss'
})
export class DeleteBookComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<DeleteBookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private bookService: BookService,
    private toastService: ToastrService) { }

  ngOnInit(): void {

  }
  onDelete() {
    this.bookService.delete(this.data.id).subscribe(response => {
      if (response.statusCode !== 200) {
        this.toastService.error(response.result);
        return;
      }
      this.toastService.success("Deleted Successfully!");
      this.dialogRef.close();
    })
  }
}
