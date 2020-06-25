import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SociosSeminariosComponent } from './socios-seminarios.component';

describe('SociosSeminariosComponent', () => {
  let component: SociosSeminariosComponent;
  let fixture: ComponentFixture<SociosSeminariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SociosSeminariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SociosSeminariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
