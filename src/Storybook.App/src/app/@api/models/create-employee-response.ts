/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface CreateEmployeeResponse {
  employee?: EmployeeDto;
  validationErrors?: Array<string>;
}
