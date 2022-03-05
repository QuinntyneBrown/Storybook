/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface CreateDonationResponse {
  donation?: DonationDto;
  validationErrors?: Array<string>;
}
