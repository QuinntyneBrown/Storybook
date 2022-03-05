/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface GetEmployeesResponse {
  employees?: Array<EmployeeDto>;
  validationErrors?: Array<string>;
}
