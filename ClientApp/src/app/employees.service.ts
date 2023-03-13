import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRoutes } from './api.routes';
import { EmployeeModel } from './models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private httpClient: HttpClient) { }
  getAllEmployees(): Observable<Array<EmployeeModel>> {
    return this.httpClient.get<Array<EmployeeModel>>(ApiRoutes.GetAllEmployees);
}

createEmployeeRecord(newEmployeeRecord: EmployeeModel) {
    return this.httpClient.post(ApiRoutes.CreateEmployeeRecord, newEmployeeRecord);
}

getEmployeeById(employeeId : string): Observable<EmployeeModel>  {
  const url = ApiRoutes.DeleteEmployee.replace(`{employeeId}`, employeeId);
  return this.httpClient.get<EmployeeModel>(url);
}


deleteEmployeeRecord(employeeId: string) {
    const url = ApiRoutes.DeleteEmployee.replace(`{employeeId}`, employeeId);
    return this.httpClient.delete(url);
}
}
