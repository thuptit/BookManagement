import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CategoryDropdownModel } from '../../category/category.model';
import { CategoryService } from '../../../services/category.service';
import { BookService } from '../../../services/book.service';
import { BookModel } from '../book.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-or-edit-book',
  templateUrl: './create-or-edit-book.component.html',
  styleUrl: './create-or-edit-book.component.scss'
})
export class CreateOrEditBookComponent implements OnInit {
  isCreateMode!: boolean;
  categories: CategoryDropdownModel[] = [];
  formGroup: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl(''),
    categoryId: new FormControl('')
  });
  isSaving: boolean = false;

  constructor(public dialogRef: MatDialogRef<CreateOrEditBookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private categoryService: CategoryService,
    private bookService: BookService,
    private toastService: ToastrService) {
  }

  ngOnInit(): void {
    if (this.data.bookId === 0) {
      this.isCreateMode = true;
    }
    else {
      this.isCreateMode = false;
      this.getBook();
    }
    this.getCategoryDropdown();
  }

  private setForm(book: BookModel) {
    this.formGroup.controls['name'].setValue(book.name);
    this.formGroup.controls['description'].setValue(book.description);
    this.formGroup.controls['categoryId'].setValue(book.categoryId);
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    const book = {
      id: this.data.bookId,
      name: this.formGroup.controls['name'].value,
      description: this.formGroup.controls['description'].value,
      categoryId: this.formGroup.controls['categoryId'].value
    } as BookModel;

    if (this.isCreateMode) {
      this.bookService.create(book).subscribe(response => {
        this.isSaving = response.isSaving;
        if (response.statusCode !== 200) {
          this.toastService.error(response.result);
          return;
        }
        this.toastService.success("Created sucessfully");
        this.dialogRef.close();
      })
    }
    else {
      this.bookService.update(book).subscribe(response => {
        this.isSaving = response.isSaving;
        if (response.statusCode !== 200) {
          this.toastService.error(response.result);
          return;
        }
        this.toastService.success("Updated sucessfully");
        this.dialogRef.close();
      })
    }
  }

  getBook() {
    this.bookService.getBook(this.data.bookId).subscribe((response) => {
      if (response?.statusCode !== 200) return;
      this.setForm(response.result);
    })
  }

  getCategoryDropdown() {
    this.categoryService.getDropdownList().subscribe((response) => {
      if (response?.statusCode !== 200)
        return;
      this.categories = response.result;
    })
  }
}
