import { TestBed } from '@angular/core/testing';

import { ServicioLocalStorageService } from './servicio-local-storage.service';

describe('ServicioLocalStorageService', () => {
  let service: ServicioLocalStorageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicioLocalStorageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
