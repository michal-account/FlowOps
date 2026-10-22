import { DatePipe } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { IncidentDto, IncidentService } from './incident.service';

@Component({
  imports: [RouterOutlet, DatePipe],
  selector: 'app-root',
  styleUrl: './app.scss',
  templateUrl: './app.html',
})
export class App implements OnInit {
 
  private incidentService = inject(IncidentService);

  incidents = signal<IncidentDto[]>([]);

  ngOnInit(): void {
    this.incidentService.getIncidents().subscribe({
      next: (data) => {
        this.incidents.set(data);
      },
      error: (err) => console.error("Błąd pobierania danych", err)
    });
  }
}
