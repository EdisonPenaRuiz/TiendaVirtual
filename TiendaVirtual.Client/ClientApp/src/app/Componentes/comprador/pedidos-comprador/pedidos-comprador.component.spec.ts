import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidosCompradorComponent } from './pedidos-comprador.component';

describe('PedidosCompradorComponent', () => {
  let component: PedidosCompradorComponent;
  let fixture: ComponentFixture<PedidosCompradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PedidosCompradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PedidosCompradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
