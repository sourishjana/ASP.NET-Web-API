import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { BookService } from '../book.service';
import { Book } from '../models/book.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {

  constructor(private service:BookService,private fb:FormBuilder,private routeLink:Router) { }

  ngOnInit(): void {
  }

  book=this.fb.group({
    title:['',Validators.required],
    description:['']
  })

  get title(){return this.book.get('title')}

  onSubmit(data:any){
    console.log(data.value)
    this.service.addBook(data.value).subscribe(resp=>{
      console.log(resp)
      this.routeLink.navigateByUrl('/')
    },err=>{
      console.log(err)
    })
  }

}
