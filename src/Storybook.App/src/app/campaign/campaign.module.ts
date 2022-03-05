import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CampaignRoutingModule } from './campaign-routing.module';
import { CampaignComponent } from './campaign.component';
import { TranslateModule } from '@ngx-translate/core';


@NgModule({
  declarations: [
    CampaignComponent
  ],
  imports: [
    CommonModule,
    CampaignRoutingModule,
    TranslateModule
  ]
})
export class CampaignModule { }
