/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface RemoveEmployeeResponse {
  employee?: EmployeeDto;
  validationErrors?: Array<string>;
}
