import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CdbCalculateRequest } from 'src/app/model/cdb-calculate-request';
import { CdbCalculateResponse } from 'src/app/model/cdb-calculate-response';
import { CdbCalculateService } from 'src/app/service/cdb-calculate.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  showResult: boolean = false;
  showErrorMessage: boolean = false;
  errorMessage: string = '';
  calculateResponse!: CdbCalculateResponse;
  calculateForm:any = FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private cdbCalculateService: CdbCalculateService
  ) {}

  ngOnInit(): void {
    this.calculateForm = this.formBuilder.group({
      initialAmount: ['',Validators.compose([Validators.required, Validators.min(1), Validators.max(1000000000000)])],
      monthlyTerm: ['',Validators.compose([Validators.required, Validators.min(1), Validators.max(60)])],
    });
  }

  getCalculation() {
    let calculateRequest = new CdbCalculateRequest(this.calculateForm.value.initialAmount, this.calculateForm.value.monthlyTerm);
    this.cdbCalculateService
      .cdbCalculate(calculateRequest)
      .pipe()
      .subscribe({
        next: (response) => {
          this.calculateResponse = response;
          this.showResult = true;
        },
        error: (err) => {
          this.showErrorMessage = true;
          this.showResult = false;
          this.errorMessage = err.error.errors.MonthlyTerm ?? err.error.errors.InitialAmount;
        },
        complete() { }
      });
  }
}
