/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface RemoveDonationResponse {
  donation?: DonationDto;
  validationErrors?: Array<string>;
}
