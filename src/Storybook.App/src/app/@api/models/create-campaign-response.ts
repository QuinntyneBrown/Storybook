/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface CreateCampaignResponse {
  campaign?: CampaignDto;
  validationErrors?: Array<string>;
}
