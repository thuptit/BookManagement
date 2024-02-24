import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookRoutingModule } from './book-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { ListBookComponent } from './list-book/list-book.component';
import { NbIconModule, NbInputModule } from '@nebular/theme';
import { HttpClientModule } from '@angular/common/http';
import { CreateOrEditBookComponent } from './create-or-edit-book/create-or-edit-book.component';
import { BookComponent } from './book.component';
import { DeleteBookComponent } from './delete-book/delete-book.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@NgModule({
  declarations: [ListBookComponent, CreateOrEditBookComponent, BookComponent, DeleteBookComponent],
  imports: [
    CommonModule,
    BookRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    MatCardModule,
    MatDialogModule,
    MatSelectModule,
    MatExpansionModule,
    MatListModule,
    MatDividerModule,
    NbIconModule,
    NbInputModule
  ]
})
export class BookModule { }
