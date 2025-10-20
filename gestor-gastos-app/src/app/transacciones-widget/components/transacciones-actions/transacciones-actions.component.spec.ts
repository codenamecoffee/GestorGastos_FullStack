import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransaccionesActionsComponent } from './transacciones-actions.component';

describe('TransaccionesActionsComponent', () => {
  let component: TransaccionesActionsComponent;
  let fixture: ComponentFixture<TransaccionesActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransaccionesActionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransaccionesActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
