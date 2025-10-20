import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Transaccion {
  id: number;
  fecha: string;  // en .NET es DateTime, en Angular viaja como string (ISO 8601)
  descripcion: string;
  categoria: string;  // el enum llega como string (ej: "Alimentos")
  monto: number;  //  decimal en .NET = number en typescript
  moneda: string;
  tipo: string;  // Pasa lo mismo que con categoria
  comprobante?: string;
  comprobanteMimeType?: string;
}

export interface FiltrosTransaccion {  // Para "filtros" en transaccion-widget.component.ts
  descripcion: string;
  tipo: string;
  categoria: string;
  desde: string;
  hasta: string;
  mimeType: string;
};

@Injectable({
  providedIn: 'root'
})

export class TransaccionService {
  private apiUrl = 'https://localhost:7274/api/transacciones';

  constructor(private http: HttpClient) { }

  obtenerTodas(): Observable<Transaccion[]>
  {
    return this.http.get<Transaccion[]>(this.apiUrl);
  }

  filtrar(filtros: any): Observable<any> {
    const params = new HttpParams({ fromObject: filtros });
    return this.http.get(`${this.apiUrl}/filtrar`, { params });
  }

  obtenerPorId(id: number): Observable<Transaccion>{
    return this.http.get<Transaccion>(`${this.apiUrl}/${id}`);
  }

  obtenerComprobante(id: number): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/${id}/comprobante`, { responseType: 'blob' });
  }

  crear(formData: FormData): Observable<any> {
    return this.http.post(this.apiUrl, formData);
  }

  actualizar(id: number, formData: FormData): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, formData);
  }

  eliminar(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
