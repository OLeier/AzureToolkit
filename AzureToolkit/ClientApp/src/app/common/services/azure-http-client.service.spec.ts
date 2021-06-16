import { TestBed } from '@angular/core/testing';

import { AzureHttpClientService } from './azure-http-client.service';

describe('AzureHttpClientService', () => {
  let service: AzureHttpClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AzureHttpClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
