import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TarjetaCuentasUsuariosComponent } from './tarjeta-cuentas-usuarios.component';

describe('CardTarjetaComponent', () => {
  let component: TarjetaCuentasUsuariosComponent;
  let fixture: ComponentFixture<TarjetaCuentasUsuariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TarjetaCuentasUsuariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TarjetaCuentasUsuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
