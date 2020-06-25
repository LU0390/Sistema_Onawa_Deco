import { TestBed } from '@angular/core/testing';

import { ProfesoresSeminariosService } from './profesores-seminarios.service';

describe('ProfesoresSeminariosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProfesoresSeminariosService = TestBed.get(ProfesoresSeminariosService);
    expect(service).toBeTruthy();
  });
});
