import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../employees.service';
import { EmployeeModel } from '../models/employee.model';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  allEmployees: Array<EmployeeModel> = [];
  displayedColumns: string[] = ['select', 'firstName', 'lastName', 'email', 'department'];

  selectedEmployeeId!: string;

  constructor(private employeesService: EmployeesService) { }

  ngOnInit(): void {
    this.getAllEmployees();

  }

  getAllEmployees() {
    this.employeesService.getAllEmployees().subscribe(employees => {
        this.allEmployees = employees;
        console.log(this.allEmployees);

    });
}

deleteEmployee() {
    if (window.confirm('Are you sure to delete employee record?')) {
        this.employeesService.deleteEmployeeRecord(this.selectedEmployeeId).subscribe(response => {
            console.log(response);
            this.getAllEmployees();
        });
    }
}



onEmployeeSelection(employeeId: string) {
    this.selectedEmployeeId = employeeId;
    console.log(this.selectedEmployeeId);
}
}
