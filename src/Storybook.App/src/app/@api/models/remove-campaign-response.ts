/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface RemoveCampaignResponse {
  campaign?: CampaignDto;
  validationErrors?: Array<string>;
}
