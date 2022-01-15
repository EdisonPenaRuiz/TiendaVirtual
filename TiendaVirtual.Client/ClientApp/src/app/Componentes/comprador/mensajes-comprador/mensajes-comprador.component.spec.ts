import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MensajesCompradorComponent } from './mensajes-comprador.component';

describe('MensajesCompradorComponent', () => {
  let component: MensajesCompradorComponent;
  let fixture: ComponentFixture<MensajesCompradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MensajesCompradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MensajesCompradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
