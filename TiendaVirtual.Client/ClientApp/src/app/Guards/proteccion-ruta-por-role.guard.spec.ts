import { TestBed } from '@angular/core/testing';

import { ProteccionRutaPorRoleGuard } from './proteccion-ruta-por-role.guard';

describe('ProteccionRutaPorRoleGuard', () => {
  let guard: ProteccionRutaPorRoleGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ProteccionRutaPorRoleGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
