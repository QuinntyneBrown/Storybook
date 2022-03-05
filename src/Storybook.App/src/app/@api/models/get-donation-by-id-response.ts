/* tslint:disable */
import { DonationDto } from './donation-dto';
export interface GetDonationByIdResponse {
  donation?: DonationDto;
  validationErrors?: Array<string>;
}
