import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transaccion-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './transaccion-form.component.html',
  styleUrl: './transaccion-form.component.scss'
})
export class TransaccionFormComponent {
  // INPUTS - Datos que SIEMPRE vienen del padre (Usan: '!')
  @Input() nuevaTransaccion!: any;
  @Input() categorias!: string[];
  @Input() tiposTransaccion!: string[]
  @Input() usarFechaPersonalizada!: boolean;
  @Input() tieneComprobanteExistente!: boolean;
  @Input() eliminarComprobante!: boolean;
  @Input() editingId!: number | null;
  @Input() agregarComprobante!: boolean

  // INPUTS - Datos que pueden ser null/false por defecto
  @Input() isSubmitting: boolean = false; 

  // Datos enviados al componente padre
  @Output() submit = new EventEmitter<any>();
  @Output() cancelar = new EventEmitter<void>();
  @Output() verComprobante = new EventEmitter<number>();
  @Output() fileSelected = new EventEmitter<Event>();
  @Output() usarFechaPersonalizadaChange = new EventEmitter<boolean>();
  @Output() eliminarComprobanteChange = new EventEmitter<boolean>();

  @Output() agregarComprobanteChange = new EventEmitter<boolean>();


  onAgregarComprobanteChange(event: Event) {
    this.agregarComprobanteChange.emit(this.agregarComprobante);
  }

  onUsarFechaPersonalizadaChange(event: Event) {
    this.usarFechaPersonalizadaChange.emit(this.usarFechaPersonalizada);
  }

  onEliminarComprobanteChange(event: Event) {
    this.eliminarComprobanteChange.emit(this.eliminarComprobante);
  }

  onSubmit(): void {
    if (this.isSubmitting) return; // ⬅️ Prevenir doble submit
    this.submit.emit();
  }
  cancelarCreacion(): void {
    this.cancelar.emit();
  }
  verComprobanteTransaccion(): void {
    if (this.editingId) { // Según si estamos editando o creando
      this.verComprobante.emit(this.editingId);
    }
  }
  onFileSelected(event: Event): void {
    this.fileSelected.emit(event);
  }
}
