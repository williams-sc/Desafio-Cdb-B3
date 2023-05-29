import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CdbCalculateService } from './cdb-calculate.service';
import { RequestService } from './request.service';

describe('CdbCalculateService', () => {
  let service: CdbCalculateService;
  let mockHttpClient: jasmine.SpyObj<HttpClient>;
  let mockRequestService: jasmine.SpyObj<RequestService>;

  beforeEach(() => {
    mockRequestService = jasmine.createSpyObj('RequestService', ['request']);
    mockHttpClient = jasmine.createSpyObj('HttpClient', ['post']);
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientTestingModule],
      providers: [
        { provide: RequestService, useValue: mockRequestService },
        { provide: HttpClient, useValue: mockHttpClient }
      ]
    });


  });

  it('should be created service', () => {
    const service: RequestService = TestBed.inject(RequestService);
    expect(service).toBeTruthy();
  });
});
