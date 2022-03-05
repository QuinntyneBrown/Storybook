/* tslint:disable */
import { EmployeeDto } from './employee-dto';
export interface GetEmployeeByIdResponse {
  employee?: EmployeeDto;
  validationErrors?: Array<string>;
}
