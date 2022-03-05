/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetEmployeeByIdResponse } from '../models/get-employee-by-id-response';
import { RemoveEmployeeResponse } from '../models/remove-employee-response';
import { GetEmployeesResponse } from '../models/get-employees-response';
import { CreateEmployeeResponse } from '../models/create-employee-response';
import { CreateEmployeeRequest } from '../models/create-employee-request';
import { UpdateEmployeeResponse } from '../models/update-employee-response';
import { UpdateEmployeeRequest } from '../models/update-employee-request';
import { GetEmployeesPageResponse } from '../models/get-employees-page-response';
@Injectable({
  providedIn: 'root',
})
class EmployeeService extends __BaseService {
  static readonly getEmployeeByIdPath = '/api/Employee/{employeeId}';
  static readonly removeEmployeePath = '/api/Employee/{employeeId}';
  static readonly getEmployeesPath = '/api/Employee';
  static readonly createEmployeePath = '/api/Employee';
  static readonly updateEmployeePath = '/api/Employee';
  static readonly getEmployeesPagePath = '/api/Employee/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get Employee by id.
   *
   * Get Employee by id.
   * @param employeeId undefined
   * @return Success
   */
  getEmployeeByIdResponse(employeeId: number): __Observable<__StrictHttpResponse<GetEmployeeByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Employee/${encodeURIComponent(String(employeeId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetEmployeeByIdResponse>;
      })
    );
  }
  /**
   * Get Employee by id.
   *
   * Get Employee by id.
   * @param employeeId undefined
   * @return Success
   */
  getEmployeeById(employeeId: number): __Observable<GetEmployeeByIdResponse> {
    return this.getEmployeeByIdResponse(employeeId).pipe(
      __map(_r => _r.body as GetEmployeeByIdResponse)
    );
  }

  /**
   * Delete Employee.
   *
   * Delete Employee.
   * @param employeeId undefined
   * @return Success
   */
  removeEmployeeResponse(employeeId: number): __Observable<__StrictHttpResponse<RemoveEmployeeResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Employee/${encodeURIComponent(String(employeeId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveEmployeeResponse>;
      })
    );
  }
  /**
   * Delete Employee.
   *
   * Delete Employee.
   * @param employeeId undefined
   * @return Success
   */
  removeEmployee(employeeId: number): __Observable<RemoveEmployeeResponse> {
    return this.removeEmployeeResponse(employeeId).pipe(
      __map(_r => _r.body as RemoveEmployeeResponse)
    );
  }

  /**
   * Get Employees.
   *
   * Get Employees.
   * @return Success
   */
  getEmployeesResponse(): __Observable<__StrictHttpResponse<GetEmployeesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Employee`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetEmployeesResponse>;
      })
    );
  }
  /**
   * Get Employees.
   *
   * Get Employees.
   * @return Success
   */
  getEmployees(): __Observable<GetEmployeesResponse> {
    return this.getEmployeesResponse().pipe(
      __map(_r => _r.body as GetEmployeesResponse)
    );
  }

  /**
   * Create Employee.
   *
   * Create Employee.
   * @param body undefined
   * @return Success
   */
  createEmployeeResponse(body?: CreateEmployeeRequest): __Observable<__StrictHttpResponse<CreateEmployeeResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Employee`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateEmployeeResponse>;
      })
    );
  }
  /**
   * Create Employee.
   *
   * Create Employee.
   * @param body undefined
   * @return Success
   */
  createEmployee(body?: CreateEmployeeRequest): __Observable<CreateEmployeeResponse> {
    return this.createEmployeeResponse(body).pipe(
      __map(_r => _r.body as CreateEmployeeResponse)
    );
  }

  /**
   * Update Employee.
   *
   * Update Employee.
   * @param body undefined
   * @return Success
   */
  updateEmployeeResponse(body?: UpdateEmployeeRequest): __Observable<__StrictHttpResponse<UpdateEmployeeResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Employee`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateEmployeeResponse>;
      })
    );
  }
  /**
   * Update Employee.
   *
   * Update Employee.
   * @param body undefined
   * @return Success
   */
  updateEmployee(body?: UpdateEmployeeRequest): __Observable<UpdateEmployeeResponse> {
    return this.updateEmployeeResponse(body).pipe(
      __map(_r => _r.body as UpdateEmployeeResponse)
    );
  }

  /**
   * Get Employee Page.
   *
   * Get Employee Page.
   * @param params The `EmployeeService.GetEmployeesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getEmployeesPageResponse(params: EmployeeService.GetEmployeesPageParams): __Observable<__StrictHttpResponse<GetEmployeesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Employee/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetEmployeesPageResponse>;
      })
    );
  }
  /**
   * Get Employee Page.
   *
   * Get Employee Page.
   * @param params The `EmployeeService.GetEmployeesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getEmployeesPage(params: EmployeeService.GetEmployeesPageParams): __Observable<GetEmployeesPageResponse> {
    return this.getEmployeesPageResponse(params).pipe(
      __map(_r => _r.body as GetEmployeesPageResponse)
    );
  }
}

module EmployeeService {

  /**
   * Parameters for getEmployeesPage
   */
  export interface GetEmployeesPageParams {
    pageSize: number;
    index: number;
  }
}

export { EmployeeService }
