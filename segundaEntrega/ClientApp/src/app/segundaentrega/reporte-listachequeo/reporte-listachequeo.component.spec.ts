import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteListachequeoComponent } from './reporte-listachequeo.component';

describe('ReporteListachequeoComponent', () => {
  let component: ReporteListachequeoComponent;
  let fixture: ComponentFixture<ReporteListachequeoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteListachequeoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteListachequeoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
