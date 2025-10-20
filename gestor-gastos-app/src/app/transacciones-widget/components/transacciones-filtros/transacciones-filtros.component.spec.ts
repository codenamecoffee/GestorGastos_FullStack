import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransaccionesFiltrosComponent } from './transacciones-filtros.component';

describe('TransaccionesFiltrosComponent', () => {
  let component: TransaccionesFiltrosComponent;
  let fixture: ComponentFixture<TransaccionesFiltrosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransaccionesFiltrosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransaccionesFiltrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
