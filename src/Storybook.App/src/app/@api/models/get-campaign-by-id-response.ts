/* tslint:disable */
import { CampaignDto } from './campaign-dto';
export interface GetCampaignByIdResponse {
  campaign?: CampaignDto;
  validationErrors?: Array<string>;
}
