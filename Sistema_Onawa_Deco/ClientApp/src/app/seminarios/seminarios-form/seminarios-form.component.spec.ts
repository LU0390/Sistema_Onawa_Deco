import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminariosFormComponent } from './seminarios-form.component';

describe('SeminariosFormComponent', () => {
  let component: SeminariosFormComponent;
  let fixture: ComponentFixture<SeminariosFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeminariosFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeminariosFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
