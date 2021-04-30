import { TestBed } from '@angular/core/testing';

import { ActitudesService } from './actitudes.service';

describe('ActitudesService', () => {
  let service: ActitudesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActitudesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
