import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from 'src/app/employees.service';
import { EmployeeModel } from 'src/app/models/employee.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  newEmployee: EmployeeModel = new EmployeeModel();

    constructor(private route: ActivatedRoute,
        private dataService: EmployeesService,
        private router: Router) { }

    ngOnInit(): void {
      const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.dataService.getEmployeeById(id).subscribe({
        next : (newEmployee) => this.newEmployee = newEmployee
      });
    }
    }

    createEmployeeRecord() {
        console.log(this.newEmployee);
        this.dataService.createEmployeeRecord(this.newEmployee).subscribe(response => {
            console.log(response);
            this.router.navigateByUrl('/employees');
        });
    }
}
