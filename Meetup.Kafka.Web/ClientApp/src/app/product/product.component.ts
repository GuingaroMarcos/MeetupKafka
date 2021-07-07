import { toBase64String } from '@angular/compiler/src/output/source_map';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { ProductService } from '../services/product/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  public products: any;
  getList$: Observable<any>;
  formProduct: FormGroup;
  constructor(private productService: ProductService, private fb: FormBuilder, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.formProduct = this.fb.group({
      name: [''],
      value: [''],
      description: [''],
      photoFile: [''],
      photoForm: [''],
      category: [''],
    });

    //this.productService.getList().subscribe(even => { this.products = even }, error => { console.log(error) });
  }

  Categories: Category[] = [
    { viewValue: 'Computing' },
    { viewValue: 'Mobile' }
  ];

  onChange(event) {
    this.formProduct.patchValue({ photoForm: event.target.files[0] });
    this.formProduct.updateValueAndValidity();
  }

  public newOrderProduct() {
    this.product = Object.assign({}, this.product, this.formProduct.value);

    this.productService.newOrderProduct(this.product).subscribe(even => {
      this.formProduct.reset();
      this.openSnackBar('Order dispatched', 'Undo');
    }, error => { console.log(error) });
  }
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
}
