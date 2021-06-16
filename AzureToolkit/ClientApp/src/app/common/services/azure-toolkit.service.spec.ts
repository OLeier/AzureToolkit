import { TestBed } from '@angular/core/testing';

import { AzureToolkitService } from './azure-toolkit.service';

describe('AzureToolkitService', () => {
  let service: AzureToolkitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AzureToolkitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
