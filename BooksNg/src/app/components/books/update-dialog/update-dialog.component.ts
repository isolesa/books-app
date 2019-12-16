import { Component, Input, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { IBook } from './../../../models/IBook';

@Component({
  selector: 'app-update-dialog-content',
  templateUrl: './update-dialog-content.component.html',
  styleUrls: ['./update-dialog-content.component.css']
})
export class UpdateDialogContentComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder, @Inject(MAT_DIALOG_DATA) public data: IBook) { }

  formGroup: FormGroup;
  post;

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
      title: [this.data.title, new FormControl('', Validators.required)],
      language: [this.data.language, Validators.required],
      publishedAt: [this.data.publishedAt, Validators.required],
      author: [this.data.author, Validators.required]
});
  }

  getError() {
    return 'Field is required';
  }

  getDescriptionError() {
    return 'Field is required. Minimum 5 characters and maximum 300 characters.';
  }

  onSubmit(post) {
    this.post = post;
  }
}

/**
 * @title Dialog with header, scrollable content and actions
 */
@Component({
  selector: 'app-update-dialog',
  templateUrl: './update-dialog.component.html',
  styleUrls: ['./update-dialog.component.css'],
})
export class UpdateDialogComponent {

  @Input() bookData: IBook;

  constructor(public dialog: MatDialog) { }

  openDialog() {
    const dialogRef = this.dialog.open(UpdateDialogContentComponent, {
      data: this.bookData
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
