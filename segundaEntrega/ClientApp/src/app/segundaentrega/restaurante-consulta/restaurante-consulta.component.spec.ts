import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestauranteConsultaComponent } from './restaurante-consulta.component';

describe('RestauranteConsultaComponent', () => {
  let component: RestauranteConsultaComponent;
  let fixture: ComponentFixture<RestauranteConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestauranteConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestauranteConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
