import { TestBed } from '@angular/core/testing';

import { CargarPermisosService } from './cargar-permisos.service';

describe('CargarPermisosService', () => {
  let service: CargarPermisosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CargarPermisosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
