import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TransaccionesWidgetComponent } from './transacciones-widget/transacciones-widget.component'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TransaccionesWidgetComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'gestor-gastos-app';
}
