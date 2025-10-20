import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Transaccion } from '../../../services/transaccion.service';


@Component({
  selector: 'app-transaccion-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './transaccion-card.component.html',
  styleUrl: './transaccion-card.component.scss'
})
export class TransaccionCardComponent {
  // INPUT - Recibe la transacción del padre
  @Input() transaccion!: Transaccion;

  // OUTPUTS - Envía eventos al padre
  @Output() editar = new EventEmitter<Transaccion>();
  @Output() eliminar = new EventEmitter<number>();
  @Output() verComprobante = new EventEmitter<number>();

  // Métodos que emiten eventos
  editarTransaccion(): void {
    this.editar.emit(this.transaccion); // Envía toda la transacción
  }

  eliminarTransaccion(): void {
    this.eliminar.emit(this.transaccion.id); // Envía solo el ID
  }

  verComprobanteTransaccion(): void {
    this.verComprobante.emit(this.transaccion.id); // Envía solo el ID
  }

  // Método para formatear fecha (movido del padre)
  mostrarFecha(fechaIso: string): string {
    if (!fechaIso) return '';
    return new Date(fechaIso).toLocaleString('es-UY', {
      dateStyle: 'short',
      timeStyle: 'short',
      hour12: false,
    });
  }

  /* Si queremos conversión dinámica a la zona horaria del cliente (no solo Uruguay):

    .toLocaleString(undefined, {
      dateStyle: 'short',
      timeStyle: 'short',
      hour12: false,
    });

    => El undefined usa la configuración regional del sistema o del navegador del usuario.

  */
}
