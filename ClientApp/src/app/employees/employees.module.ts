import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesComponent } from './employees.component';
import { SharedMatModule } from '../shared/shared-mat.module';
import { EmployeesRoutingModule } from './employees-routing.module';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';


@NgModule({
  declarations: [EmployeesComponent, EditEmployeeComponent],
  imports: [
    CommonModule,
    SharedMatModule,
    EmployeesRoutingModule
  ]
})
export class EmployeesModule { }
