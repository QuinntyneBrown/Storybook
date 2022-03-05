import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';


@Component({
  selector: 'sb-campaign',
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.scss']
})
export class CampaignComponent {

  readonly vm$ = combine([
    of("campaign")
  ])
  .pipe(
    map(([name]) => ({ name }))
  );

  constructor(

  ) {

  }
}
