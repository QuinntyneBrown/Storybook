/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetCampaignByIdResponse } from '../models/get-campaign-by-id-response';
import { RemoveCampaignResponse } from '../models/remove-campaign-response';
import { GetCampaignsResponse } from '../models/get-campaigns-response';
import { CreateCampaignResponse } from '../models/create-campaign-response';
import { CreateCampaignRequest } from '../models/create-campaign-request';
import { UpdateCampaignResponse } from '../models/update-campaign-response';
import { UpdateCampaignRequest } from '../models/update-campaign-request';
import { GetCampaignsPageResponse } from '../models/get-campaigns-page-response';
@Injectable({
  providedIn: 'root',
})
class CampaignService extends __BaseService {
  static readonly getCampaignByIdPath = '/api/Campaign/{campaignId}';
  static readonly removeCampaignPath = '/api/Campaign/{campaignId}';
  static readonly getCampaignsPath = '/api/Campaign';
  static readonly createCampaignPath = '/api/Campaign';
  static readonly updateCampaignPath = '/api/Campaign';
  static readonly getCampaignsPagePath = '/api/Campaign/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get Campaign by id.
   *
   * Get Campaign by id.
   * @param campaignId undefined
   * @return Success
   */
  getCampaignByIdResponse(campaignId: number): __Observable<__StrictHttpResponse<GetCampaignByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Campaign/${encodeURIComponent(String(campaignId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCampaignByIdResponse>;
      })
    );
  }
  /**
   * Get Campaign by id.
   *
   * Get Campaign by id.
   * @param campaignId undefined
   * @return Success
   */
  getCampaignById(campaignId: number): __Observable<GetCampaignByIdResponse> {
    return this.getCampaignByIdResponse(campaignId).pipe(
      __map(_r => _r.body as GetCampaignByIdResponse)
    );
  }

  /**
   * Delete Campaign.
   *
   * Delete Campaign.
   * @param campaignId undefined
   * @return Success
   */
  removeCampaignResponse(campaignId: number): __Observable<__StrictHttpResponse<RemoveCampaignResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Campaign/${encodeURIComponent(String(campaignId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveCampaignResponse>;
      })
    );
  }
  /**
   * Delete Campaign.
   *
   * Delete Campaign.
   * @param campaignId undefined
   * @return Success
   */
  removeCampaign(campaignId: number): __Observable<RemoveCampaignResponse> {
    return this.removeCampaignResponse(campaignId).pipe(
      __map(_r => _r.body as RemoveCampaignResponse)
    );
  }

  /**
   * Get Campaigns.
   *
   * Get Campaigns.
   * @return Success
   */
  getCampaignsResponse(): __Observable<__StrictHttpResponse<GetCampaignsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Campaign`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCampaignsResponse>;
      })
    );
  }
  /**
   * Get Campaigns.
   *
   * Get Campaigns.
   * @return Success
   */
  getCampaigns(): __Observable<GetCampaignsResponse> {
    return this.getCampaignsResponse().pipe(
      __map(_r => _r.body as GetCampaignsResponse)
    );
  }

  /**
   * Create Campaign.
   *
   * Create Campaign.
   * @param body undefined
   * @return Success
   */
  createCampaignResponse(body?: CreateCampaignRequest): __Observable<__StrictHttpResponse<CreateCampaignResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Campaign`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateCampaignResponse>;
      })
    );
  }
  /**
   * Create Campaign.
   *
   * Create Campaign.
   * @param body undefined
   * @return Success
   */
  createCampaign(body?: CreateCampaignRequest): __Observable<CreateCampaignResponse> {
    return this.createCampaignResponse(body).pipe(
      __map(_r => _r.body as CreateCampaignResponse)
    );
  }

  /**
   * Update Campaign.
   *
   * Update Campaign.
   * @param body undefined
   * @return Success
   */
  updateCampaignResponse(body?: UpdateCampaignRequest): __Observable<__StrictHttpResponse<UpdateCampaignResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Campaign`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateCampaignResponse>;
      })
    );
  }
  /**
   * Update Campaign.
   *
   * Update Campaign.
   * @param body undefined
   * @return Success
   */
  updateCampaign(body?: UpdateCampaignRequest): __Observable<UpdateCampaignResponse> {
    return this.updateCampaignResponse(body).pipe(
      __map(_r => _r.body as UpdateCampaignResponse)
    );
  }

  /**
   * Get Campaign Page.
   *
   * Get Campaign Page.
   * @param params The `CampaignService.GetCampaignsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getCampaignsPageResponse(params: CampaignService.GetCampaignsPageParams): __Observable<__StrictHttpResponse<GetCampaignsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Campaign/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCampaignsPageResponse>;
      })
    );
  }
  /**
   * Get Campaign Page.
   *
   * Get Campaign Page.
   * @param params The `CampaignService.GetCampaignsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getCampaignsPage(params: CampaignService.GetCampaignsPageParams): __Observable<GetCampaignsPageResponse> {
    return this.getCampaignsPageResponse(params).pipe(
      __map(_r => _r.body as GetCampaignsPageResponse)
    );
  }
}

module CampaignService {

  /**
   * Parameters for getCampaignsPage
   */
  export interface GetCampaignsPageParams {
    pageSize: number;
    index: number;
  }
}

export { CampaignService }
