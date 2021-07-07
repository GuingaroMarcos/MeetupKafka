import { toBase64String } from '@angular/compiler/src/output/source_map';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { ProductService } from '../services/product/product.service';

interface Category {
  viewValue: string;
}

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  public product: Product;
  public products: Product[];
  getList$: Observable<any>;
  formProduct: FormGroup;
  base64String: string;
  constructor(private productService: ProductService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.formProduct = this.fb.group({
      name: [''],
      value: [''],
      description: [''],
      photoBase64: [''],
      category: [''],
    });
    this.productService.getList().subscribe(even => {  }, error => { console.log(error) });
  }

  Categories: Category[] = [
    { viewValue: 'Computing' },
    { viewValue: 'Mobile' }
  ];

  onChange(event) {
    let file = event.target.files[0];
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.base64String = reader.result as string;
    }
    setTimeout(() => {
      this.formProduct.patchValue({ photo: this.base64String });
      this.formProduct.updateValueAndValidity();
    }, 10)
  }

  public newOrderProduct() {
    this.product = Object.assign({}, this.product, this.formProduct.value);
    this.product.photoBase64 = this.base64String;
    this.productService.newOrderProduct(this.product).subscribe(even => { }, error => { console.log(error) });
  }

}
