import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminariosComponent } from './seminarios.component';

describe('SeminariosComponent', () => {
  let component: SeminariosComponent;
  let fixture: ComponentFixture<SeminariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeminariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeminariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
