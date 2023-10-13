import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoradorDetalheComponent } from './morador-detalhe.component';

describe('MoradorDetalheComponent', () => {
  let component: MoradorDetalheComponent;
  let fixture: ComponentFixture<MoradorDetalheComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MoradorDetalheComponent]
    });
    fixture = TestBed.createComponent(MoradorDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
