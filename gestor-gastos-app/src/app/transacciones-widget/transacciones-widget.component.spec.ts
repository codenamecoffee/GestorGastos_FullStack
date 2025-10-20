import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransaccionesWidgetComponent } from './transacciones-widget.component';

describe('TransaccionesWidgetComponent', () => {
  let component: TransaccionesWidgetComponent;
  let fixture: ComponentFixture<TransaccionesWidgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransaccionesWidgetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransaccionesWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
