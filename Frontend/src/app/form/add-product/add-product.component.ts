import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {

  categories: {name:string,type:string}[] = [
    {name: 'Opreme',type:'e'},
    {name: 'Suplementi',type:'s'},
    ];

  selectedCategory: {name:string,type:string};
  constructor() { }

  ngOnInit(): void {
  }

}
