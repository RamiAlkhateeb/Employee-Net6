import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditEmployeeComponent } from './edit-employee.component';

const routes: Routes = [{ path: '', component: EditEmployeeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditEmployeeRoutingModule { }
