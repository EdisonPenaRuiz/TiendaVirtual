import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardPedidosCompradorComponent } from './card-pedidos-usuarios.component';

describe('CardPedidosCompradorComponent', () => {
  let component: CardPedidosCompradorComponent;
  let fixture: ComponentFixture<CardPedidosCompradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardPedidosCompradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CardPedidosCompradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
