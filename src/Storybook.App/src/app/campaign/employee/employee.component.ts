import { Component, NgModule } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';
import { EmployeeFeatureService } from './employee-feature.service';


@Component({
  selector: 'sb-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  providers: [
    EmployeeFeatureService
  ]
})
export class EmployeeComponent {

  readonly vm$ = combine([
    of("employee")
  ])
  .pipe(
    map(([name]) => ({ name }))
  );

  constructor(

  ) {

  }
}
