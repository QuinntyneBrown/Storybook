/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface GetDonationsResponse {
  donations?: Array<DonationDto>;
  validationErrors?: Array<string>;
}
