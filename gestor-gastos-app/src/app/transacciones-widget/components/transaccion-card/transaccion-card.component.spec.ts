import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransaccionCardComponent } from './transaccion-card.component';

describe('TransaccionCardComponent', () => {
  let component: TransaccionCardComponent;
  let fixture: ComponentFixture<TransaccionCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransaccionCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransaccionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
