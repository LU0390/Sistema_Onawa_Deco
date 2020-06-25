import { TestBed } from '@angular/core/testing';

import { SeminariosSociosService } from './seminarios-socios.service';

describe('SeminariosSociosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SeminariosSociosService = TestBed.get(SeminariosSociosService);
    expect(service).toBeTruthy();
  });
});
