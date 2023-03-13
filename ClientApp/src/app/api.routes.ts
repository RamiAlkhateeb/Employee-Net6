import { environment } from '../environments/environment';

export const ApiRoutes = {
    GetAllEmployees: environment.apiUrl + `/employees`,
    DeleteEmployee: environment.apiUrl + `/employees/{employeeId}`,
    CreateEmployeeRecord: environment.apiUrl + `/employees`,
    GetEmployee:environment.apiUrl+`/employees/{employeeId}`
};
