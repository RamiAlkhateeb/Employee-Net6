import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditEmployeeRoutingModule } from './edit-employee-routing.module';
import { EditEmployeeComponent } from './edit-employee.component';
import { SharedMatModule } from '../../../app/shared/shared-mat.module';


@NgModule({
  declarations: [EditEmployeeComponent],
  imports: [
    CommonModule,
    SharedMatModule,
    EditEmployeeRoutingModule
  ]
})
export class NewEmployeeModule { }
