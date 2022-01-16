import { TestBed } from '@angular/core/testing';

import { ServicioFormasPagosUsuariosService } from './servicio-formas-pagos-usuarios.service';

describe('ServicioFormasPagosUsuariosService', () => {
  let service: ServicioFormasPagosUsuariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicioFormasPagosUsuariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
