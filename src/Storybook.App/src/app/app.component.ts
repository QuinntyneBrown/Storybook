import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'sb-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private readonly _translateService: TranslateService) {
    _translateService.setDefaultLang("en-CA");
    _translateService.use(localStorage.getItem("storybook.app:lang") || 'en-CA');
  }
}
