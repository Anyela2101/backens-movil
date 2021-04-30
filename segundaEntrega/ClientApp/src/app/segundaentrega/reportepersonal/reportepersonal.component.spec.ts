import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportepersonalComponent } from './reportepersonal.component';

describe('ReportepersonalComponent', () => {
  let component: ReportepersonalComponent;
  let fixture: ComponentFixture<ReportepersonalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportepersonalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportepersonalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
