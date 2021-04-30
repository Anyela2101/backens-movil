import { TestBed } from '@angular/core/testing';

import { ListaChequeoService } from './lista-chequeo.service';

describe('ListaChequeoService', () => {
  let service: ListaChequeoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ListaChequeoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
