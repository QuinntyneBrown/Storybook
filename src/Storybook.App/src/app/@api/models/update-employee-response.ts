/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface UpdateEmployeeResponse {
  employee?: EmployeeDto;
  validationErrors?: Array<string>;
}
