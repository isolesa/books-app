import { IBook } from './../../../models/IBook';
import { BooksService } from './../../../services/books/books.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

/**
 * @title Table with pagination
 */
@Component({
  selector: 'app-data-table',
  styleUrls: ['data-table.component.css'],
  templateUrl: 'data-table.component.html',
})
export class DataTableComponent implements OnInit {

  constructor(private booksService: BooksService) {

  }

  displayedColumns: string[] = ['title', 'language', 'publishedAt', 'author', 'id'];
  books: IBook[];

  dataSource: MatTableDataSource<IBook>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  ngOnInit() {
    this.booksService.get()
      .subscribe(
        (res) => {
          this.books = res;
        }
        ,
        (error) => console.error('Error' + error),
        () => {
          this.dataSource = new MatTableDataSource<IBook>(this.books);
          this.dataSource.paginator = this.paginator;
        }
      );
  }
}
