import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoradorApartamentoDetalheComponent } from './morador-apartamento-detalhe.component';

describe('MoradorApartamentoDetalheComponent', () => {
  let component: MoradorApartamentoDetalheComponent;
  let fixture: ComponentFixture<MoradorApartamentoDetalheComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MoradorApartamentoDetalheComponent]
    });
    fixture = TestBed.createComponent(MoradorApartamentoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
