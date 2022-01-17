import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardTarjetaComponent } from './card-cuentas-usuarios.component';

describe('CardTarjetaComponent', () => {
  let component: CardTarjetaComponent;
  let fixture: ComponentFixture<CardTarjetaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardTarjetaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardTarjetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
