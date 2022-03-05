import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'sb-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(public translateService: TranslateService) {
    translateService.setDefaultLang("en-CA");
    translateService.use(localStorage.getItem("storybook.app:lang") || 'en-CA');
  }
}
