/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface UpdateDonationResponse {
  donation?: DonationDto;
  validationErrors?: Array<string>;
}
