import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-transacciones-actions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './transacciones-actions.component.html',
  styleUrl: './transacciones-actions.component.scss'
})
export class TransaccionesActionsComponent {
  // INPUTS - Recibe datos del padre
  @Input() mostrarFormulario: boolean = false;
  @Input() mostrarComprobante: boolean = false;
  @Input() mostrarBuscador: boolean = false;

  // OUTPUTS - Envía eventos al padre
  @Output() nuevaTransaccion = new EventEmitter<void>();
  @Output() abrirBuscador = new EventEmitter<void>();

  // Métodos que solo emiten eventos
  showForm(): void {
    this.nuevaTransaccion.emit();
  }

  showBuscador(): void {
    this.abrirBuscador.emit();
  }
}
