import { TestBed } from '@angular/core/testing';

import { SuplementService } from './suplement.service';

describe('SuplementService', () => {
  let service: SuplementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuplementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
