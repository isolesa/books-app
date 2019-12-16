// Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './modules/routing/app-routing.module';
import { SharedModule } from './modules/shared/shared.module';

// Components
import { AppComponent } from './app.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { HomeComponent } from './components/home/home.component';
import { BooksComponent } from './components/books/books.component';
import { NewBookComponent } from './components/new-book/new-book.component';
import { UpdateDialogComponent } from './components/books/update-dialog/update-dialog.component';
import { UpdateDialogContentComponent } from './components/books/update-dialog/update-dialog.component';
import { DataTableComponent } from './components/books/data-table/data-table.component';

// Services
import { BooksService } from './services/books/books.service';


@NgModule({
  declarations: [
    AppComponent,
    SidenavComponent,
    HomeComponent,
    DataTableComponent,
    BooksComponent,
    NewBookComponent,
    UpdateDialogComponent,
    UpdateDialogContentComponent

  ],
  entryComponents: [
    UpdateDialogContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [
    BooksService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
