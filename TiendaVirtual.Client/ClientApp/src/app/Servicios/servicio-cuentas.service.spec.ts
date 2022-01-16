import { TestBed } from '@angular/core/testing';

import { ServicioCuentasService } from './servicio-cuentas.service';

describe('ServicioCuentasService', () => {
  let service: ServicioCuentasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicioCuentasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
