import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CdbCalculateRequest } from '../model/cdb-calculate-request';
import { RequestService } from './request.service';

@Injectable({
  providedIn: 'root'
})
export class CdbCalculateService {

  constructor(private requestService: RequestService) { }

  cdbCalculate(cdbCalculateRequest: CdbCalculateRequest): Observable<any> {
    return this.requestService.request(
      'post',
      'cdbcalculator',
      'public',
      cdbCalculateRequest
    );
  }
}
