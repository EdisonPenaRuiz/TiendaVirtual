import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuentasCompradorComponent } from './cuentas-comprador.component';

describe('CuentasCompradorComponent', () => {
  let component: CuentasCompradorComponent;
  let fixture: ComponentFixture<CuentasCompradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CuentasCompradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CuentasCompradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
