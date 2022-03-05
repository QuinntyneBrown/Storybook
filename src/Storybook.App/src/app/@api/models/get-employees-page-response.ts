/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface GetEmployeesPageResponse {
  entities?: Array<EmployeeDto>;
  length?: number;
  validationErrors?: Array<string>;
}
