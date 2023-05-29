import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldControl, MatFormFieldModule } from '@angular/material/form-field';
import { RouterTestingModule } from '@angular/router/testing';
import { throwError } from 'rxjs';
import { of } from 'rxjs/internal/observable/of';
import { FooterComponent } from 'src/app/components/shared/footer/footer.component';
import { HeaderComponent } from 'src/app/components/shared/header/header.component';
import { CdbCalculateResponse } from 'src/app/model/cdb-calculate-response';
import { CdbCalculateService } from 'src/app/service/cdb-calculate.service';
1
import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let service: CdbCalculateService;
  let cdbCalculateResponse: CdbCalculateResponse;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormsModule, 
        HttpClientTestingModule,
        RouterTestingModule,
        ReactiveFormsModule],
      declarations: [ HomeComponent, HeaderComponent, FooterComponent ],
      providers: [{
        provide: FormBuilder, useValue: new FormBuilder()
      }]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    service = TestBed.inject(CdbCalculateService);
    cdbCalculateResponse = new CdbCalculateResponse(1923,1920);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should do a valid calculate request', () => {
    spyOn(service, 'cdbCalculate').and.returnValue(of(CdbCalculateResponse));
    component.calculateForm.controls['initialAmount'].setValue(1000);
    component.calculateForm.controls['monthlyTerm'].setValue(1);
    component.getCalculation();
    expect(component.showResult).toBeTruthy();
    expect(component.showErrorMessage).toBeFalsy();
  });
});
