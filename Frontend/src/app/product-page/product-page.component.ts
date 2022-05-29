import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { Product } from '../models/Product.model';
import { AuthService } from '../services/auth.service';
import { EquipmentService } from '../services/equipment.service';
import { SuplementService } from '../services/suplement.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {

  constructor(private equipmentService:EquipmentService,private suplementService:SuplementService,
              private authService:AuthService) { }


  products:Product[] = [];
  totalPages:number;
  currentPage:number = 1;
  currentRows:number = 1;
  role:string;

  rowsPerPageOptions:number[] = [1,5,10];

  categories: {name:string,type:string}[] = [
    {name: 'Opreme',type:'e'},
    {name: 'Suplementi',type:'s'},
    ];

  selectedCategory: {name:string,type:string};

  ngOnInit(): void {

    let productType = this.getTypeFromStorage();
      if(!!productType){
        this.selectedCategory = this.categories.filter(cat => cat.type === productType)[0];
      }else{
        this.selectedCategory = this.categories[0];
        localStorage.setItem("prod_type",this.selectedCategory.type);
      }
      this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows);
      this.role = this.authService.role;

}

getTypeFromStorage():string{
  return localStorage.getItem("prod_type")
}

onDropDownChange(dropDown:FormControl){
  localStorage.setItem("prod_type",dropDown.value.type)
  this.loadProducts(dropDown.value.type,this.currentPage,this.currentRows);
}

loadProducts(type:string,currPage:number,rowsPerPage:number){

  switch (type){
    case 'e':
      this.equipmentService.getEquipments(rowsPerPage,currPage,null).subscribe(equipments =>{
        this.products = []
        this.products.push(...equipments.equipments)
        console.log(equipments.equipments)
        this.totalPages=equipments.totalPages;
        this.currentPage = equipments.currentPage;

      });
      break;
    case 's':
      this.suplementService.getSuplements(rowsPerPage,currPage,null).subscribe(suplements =>{
        this.products = []
        this.products.push(...suplements.suplements)
        this.totalPages=suplements.totalPages;
        this.currentPage = suplements.currentPage;
      });
  }
}

onPageChange(pageData:any){
  //event.first = Index of the first record
        //event.rows = Number of rows to display in new page
        //event.page = Index of the new page
        //event.pageCount = Total number of pages
    this.currentPage = pageData.page + 1

    this.currentRows = pageData.rows
    this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows);
}
}
