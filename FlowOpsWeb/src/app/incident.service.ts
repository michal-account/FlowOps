import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface IncidentDto {
    id: string;
    title: string;
    description: string;
    priority: number;
    status: number;
    createdAt: string;
    slaDeadline: string;
}

@Injectable({ providedIn: 'root'})
export class IncidentService {
    private http = inject(HttpClient);
    private apiUrl = 'https://localhost:7066/api/incidents';

    getIncidents(): Observable<IncidentDto[]> {
        return this.http.get<IncidentDto[]>(this.apiUrl);
    }
}