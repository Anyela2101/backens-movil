import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteencuestaComponent } from './reporteencuesta.component';

describe('ReporteencuestaComponent', () => {
  let component: ReporteencuestaComponent;
  let fixture: ComponentFixture<ReporteencuestaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteencuestaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteencuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
