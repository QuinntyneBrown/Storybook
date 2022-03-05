/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetDonationByIdResponse } from '../models/get-donation-by-id-response';
import { RemoveDonationResponse } from '../models/remove-donation-response';
import { GetDonationsResponse } from '../models/get-donations-response';
import { CreateDonationResponse } from '../models/create-donation-response';
import { CreateDonationRequest } from '../models/create-donation-request';
import { UpdateDonationResponse } from '../models/update-donation-response';
import { UpdateDonationRequest } from '../models/update-donation-request';
import { GetDonationsPageResponse } from '../models/get-donations-page-response';
@Injectable({
  providedIn: 'root',
})
class DonationService extends __BaseService {
  static readonly getDonationByIdPath = '/api/Donation/{donationId}';
  static readonly removeDonationPath = '/api/Donation/{donationId}';
  static readonly getDonationsPath = '/api/Donation';
  static readonly createDonationPath = '/api/Donation';
  static readonly updateDonationPath = '/api/Donation';
  static readonly getDonationsPagePath = '/api/Donation/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get Donation by id.
   *
   * Get Donation by id.
   * @param donationId undefined
   * @return Success
   */
  getDonationByIdResponse(donationId: number): __Observable<__StrictHttpResponse<GetDonationByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Donation/${encodeURIComponent(String(donationId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDonationByIdResponse>;
      })
    );
  }
  /**
   * Get Donation by id.
   *
   * Get Donation by id.
   * @param donationId undefined
   * @return Success
   */
  getDonationById(donationId: number): __Observable<GetDonationByIdResponse> {
    return this.getDonationByIdResponse(donationId).pipe(
      __map(_r => _r.body as GetDonationByIdResponse)
    );
  }

  /**
   * Delete Donation.
   *
   * Delete Donation.
   * @param donationId undefined
   * @return Success
   */
  removeDonationResponse(donationId: number): __Observable<__StrictHttpResponse<RemoveDonationResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Donation/${encodeURIComponent(String(donationId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveDonationResponse>;
      })
    );
  }
  /**
   * Delete Donation.
   *
   * Delete Donation.
   * @param donationId undefined
   * @return Success
   */
  removeDonation(donationId: number): __Observable<RemoveDonationResponse> {
    return this.removeDonationResponse(donationId).pipe(
      __map(_r => _r.body as RemoveDonationResponse)
    );
  }

  /**
   * Get Donations.
   *
   * Get Donations.
   * @return Success
   */
  getDonationsResponse(): __Observable<__StrictHttpResponse<GetDonationsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Donation`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDonationsResponse>;
      })
    );
  }
  /**
   * Get Donations.
   *
   * Get Donations.
   * @return Success
   */
  getDonations(): __Observable<GetDonationsResponse> {
    return this.getDonationsResponse().pipe(
      __map(_r => _r.body as GetDonationsResponse)
    );
  }

  /**
   * Create Donation.
   *
   * Create Donation.
   * @param body undefined
   * @return Success
   */
  createDonationResponse(body?: CreateDonationRequest): __Observable<__StrictHttpResponse<CreateDonationResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Donation`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateDonationResponse>;
      })
    );
  }
  /**
   * Create Donation.
   *
   * Create Donation.
   * @param body undefined
   * @return Success
   */
  createDonation(body?: CreateDonationRequest): __Observable<CreateDonationResponse> {
    return this.createDonationResponse(body).pipe(
      __map(_r => _r.body as CreateDonationResponse)
    );
  }

  /**
   * Update Donation.
   *
   * Update Donation.
   * @param body undefined
   * @return Success
   */
  updateDonationResponse(body?: UpdateDonationRequest): __Observable<__StrictHttpResponse<UpdateDonationResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Donation`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateDonationResponse>;
      })
    );
  }
  /**
   * Update Donation.
   *
   * Update Donation.
   * @param body undefined
   * @return Success
   */
  updateDonation(body?: UpdateDonationRequest): __Observable<UpdateDonationResponse> {
    return this.updateDonationResponse(body).pipe(
      __map(_r => _r.body as UpdateDonationResponse)
    );
  }

  /**
   * Get Donation Page.
   *
   * Get Donation Page.
   * @param params The `DonationService.GetDonationsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getDonationsPageResponse(params: DonationService.GetDonationsPageParams): __Observable<__StrictHttpResponse<GetDonationsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Donation/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDonationsPageResponse>;
      })
    );
  }
  /**
   * Get Donation Page.
   *
   * Get Donation Page.
   * @param params The `DonationService.GetDonationsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getDonationsPage(params: DonationService.GetDonationsPageParams): __Observable<GetDonationsPageResponse> {
    return this.getDonationsPageResponse(params).pipe(
      __map(_r => _r.body as GetDonationsPageResponse)
    );
  }
}

module DonationService {

  /**
   * Parameters for getDonationsPage
   */
  export interface GetDonationsPageParams {
    pageSize: number;
    index: number;
  }
}

export { DonationService }
