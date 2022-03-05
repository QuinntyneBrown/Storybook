/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface UpdateCampaignResponse {
  campaign?: CampaignDto;
  validationErrors?: Array<string>;
}
