/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface GetCampaignsResponse {
  campaigns?: Array<CampaignDto>;
  validationErrors?: Array<string>;
}
