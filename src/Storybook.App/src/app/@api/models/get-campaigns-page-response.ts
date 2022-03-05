/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface GetCampaignsPageResponse {
  entities?: Array<CampaignDto>;
  length?: number;
  validationErrors?: Array<string>;
}
