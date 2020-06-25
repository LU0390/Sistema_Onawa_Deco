import { TestBed } from '@angular/core/testing';

import { SeminarioService } from './seminario.service';

describe('SeminarioService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SeminarioService = TestBed.get(SeminarioService);
    expect(service).toBeTruthy();
  });
});
