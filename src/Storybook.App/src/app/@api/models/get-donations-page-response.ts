/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface GetDonationsPageResponse {
  entities?: Array<DonationDto>;
  length?: number;
  validationErrors?: Array<string>;
}
