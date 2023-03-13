import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeesService } from 'src/app/employees.service';
import { EmployeeModel } from 'src/app/models/employee.model';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.css']
})
export class NewEmployeeComponent implements OnInit {

  newEmployee: EmployeeModel = new EmployeeModel();

    constructor(
        private dataService: EmployeesService,
        private router: Router) { }

    ngOnInit(): void {
    }

    createEmployeeRecord() {
        console.log(this.newEmployee);
        this.dataService.createEmployeeRecord(this.newEmployee).subscribe(response => {
            console.log(response);
            this.router.navigateByUrl('/employees');
        });
    }
}
