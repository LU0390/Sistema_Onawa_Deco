import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminariosSociosComponent } from './seminarios-socios.component';

describe('SeminariosSociosComponent', () => {
  let component: SeminariosSociosComponent;
  let fixture: ComponentFixture<SeminariosSociosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeminariosSociosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeminariosSociosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
