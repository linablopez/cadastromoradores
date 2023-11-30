import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoradorApartamentoComponent } from './morador-apartamento.component';

describe('MoradorApartamentoComponent', () => {
  let component: MoradorApartamentoComponent;
  let fixture: ComponentFixture<MoradorApartamentoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MoradorApartamentoComponent]
    });
    fixture = TestBed.createComponent(MoradorApartamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
