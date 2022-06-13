import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { SelectItem } from 'primeng/api';
import { Product } from '../models/Product.model';
import { SuplementType } from '../models/SuplementType.model';
import { AuthService } from '../services/auth.service';
import { EquipmentTypeService } from '../services/equipment-type.service';
import { EquipmentService } from '../services/equipment.service';
import { SuplementTypeService } from '../services/suplement-type.service';
import { SuplementService } from '../services/suplement.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {

  constructor(private equipmentService:EquipmentService,private suplementService:SuplementService,
              private authService:AuthService,
              private equipmentTypeService:EquipmentTypeService,
              private suplementTypeService:SuplementTypeService) { }

    searchText:string

  products:Product[] = [];
  totalPages:number;
  currentPage:number = 1;
  currentRows:number = 5;
  role:string;

  productTypes:{name:string,id:string}[] = [];
  selectedProductType:{name:string,id:string} = {name:null,id:null};


  priceSortingCategories:{orderBy:string,name:string}[] = [{orderBy:'price_desc',name:"Opadajuće"},
                                                          {orderBy:'price_asc',name:"Rastuće"}];
  currentPriceSorting:string = 'default';
  selectedPriceSorting:{orderBy:string,name:string};


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
      this.loadProductType();
      this.role = this.authService.role;



}

getTypeFromStorage():string{
  return localStorage.getItem("prod_type")
}

onDropDownChange(dropDown:FormControl){
  this.productTypes = [];
  this.searchText = null;
  this.loadProductType();
  localStorage.setItem("prod_type",dropDown.value.type)

  this.loadProducts(dropDown.value.type,this.currentPage,this.currentRows);
}

loadProducts(type:string,currPage:number,rowsPerPage:number,name:string = null,productId:string = null){

  switch (type){
    case 'e':
      this.equipmentService.getEquipments(rowsPerPage,currPage,name,this.currentPriceSorting,productId).subscribe(equipments =>{
        this.products = []
        if(!!equipments){
          this.products.push(...equipments.equipments)
          console.log(equipments.equipments)
          this.totalPages=equipments.totalPages;
          this.currentPage = equipments.currentPage;
        }
      });
      break;
    case 's':
      this.suplementService.getSuplements(rowsPerPage,currPage,name,this.currentPriceSorting,productId).subscribe({
        next: suplements =>{
          this.products = []
        if(!!suplements){
          this.products.push(...suplements.suplements)
          this.totalPages=suplements.totalPages;
          this.currentPage = suplements.currentPage;
        }
      }});

      break;
  }
}


loadProductType(){
  switch(this.selectedCategory.type){
    case 'e':
      this.equipmentTypeService.getEquipmentTypes().subscribe(et =>{
        et.forEach(e =>{
          this.productTypes.push({name:e.name,id:e.equipmentTypeId});

        });
        this.productTypes.push({name:"Svi",id:null})
    });
      break;
    case 's':
      this.suplementTypeService.getSuplementTypes().subscribe(st =>{
        st.forEach(s =>{
          this.productTypes.push({name:s.name,id:s.suplementTypeId})
        });
      });
      this.productTypes.push({name:"Svi",id:null});
      break;
  }


}

onPageChange(pageData:any){
  //event.first = Index of the first record
        //event.rows = Number of rows to display in new page
        //event.page = Index of the new page
        //event.pageCount = Total number of pages
    this.currentPage = pageData.page + 1;

    this.currentRows = pageData.rows

    this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows,this.searchText,this.selectedProductType.id);
}

onProductTypeChange(dropDown:FormControl){

  this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows,this.searchText,this.selectedProductType.id)
}

onPriceSortingChange(dropDown:FormControl){
  this.currentPriceSorting = dropDown.value.orderBy;
  let typeId:string = null
  if(!!this.selectedProductType){
      typeId = this.selectedProductType.id
  }
  this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows,this.searchText,typeId)
}

onSearch(){
  let typeId:string = null
  if(!!this.selectedProductType){
      typeId = this.selectedProductType.id
  }
  this.loadProducts(this.selectedCategory.type,this.currentPage,this.currentRows,this.searchText,typeId)
}


}

