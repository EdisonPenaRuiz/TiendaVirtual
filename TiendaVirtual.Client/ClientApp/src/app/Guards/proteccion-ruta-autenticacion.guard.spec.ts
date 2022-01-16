import { TestBed } from '@angular/core/testing';

import { ProteccionRutaAutenticacionGuard } from './proteccion-ruta-autenticacion.guard';

describe('ProteccionRutaAutenticacionGuard', () => {
  let guard: ProteccionRutaAutenticacionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ProteccionRutaAutenticacionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
