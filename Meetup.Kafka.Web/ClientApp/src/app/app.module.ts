import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';

import { LayoutComponent } from './layouts/layout/layout.component';
import { ProductComponent } from './product/product.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
//import { NgxMatFileInputModule } from '@angular-material-components/file-input';
import { ProductService } from './services/product/product.service';
import { NotificationService } from './services/Notification/notification.service';
import { MaterialFileInputModule } from 'ngx-material-file-input';
@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    //NgxMatFileInputModule,
    MaterialFileInputModule,
  ],
  declarations: [
    AppComponent,
    LayoutComponent,
    ProductComponent,

  ],
  providers: [ProductService, NotificationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
