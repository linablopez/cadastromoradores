import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApartamentoDetalheComponent } from './apartamento-detalhe.component';

describe('ApartamentoDetalheComponent', () => {
  let component: ApartamentoDetalheComponent;
  let fixture: ComponentFixture<ApartamentoDetalheComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ApartamentoDetalheComponent]
    });
    fixture = TestBed.createComponent(ApartamentoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
