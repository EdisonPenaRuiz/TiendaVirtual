import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormasPagosCompradorComponent } from './formas-pagos-usuarios.component';

describe('FormasPagosCompradorComponent', () => {
  let component: FormasPagosCompradorComponent;
  let fixture: ComponentFixture<FormasPagosCompradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormasPagosCompradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormasPagosCompradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
