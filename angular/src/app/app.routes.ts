import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '', redirectTo: 'book', pathMatch: 'full'
    },
    {
        path: 'category', loadChildren: () => import('./category/category.module').then(m => m.CategoryModule)
    },
    {
        path: 'book', loadChildren: () => import('./book/book.module').then(m => m.BookModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
