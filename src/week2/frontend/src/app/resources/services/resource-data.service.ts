import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { ResourceListItem } from '../types';
import { environment } from '../../../environments/environment';
export class ResourceDataService {
  private readonly URL = environment.apiUrl;

  private client = inject(HttpClient);

  getResource() {
    return this.client.get<ResourceListItem[]>(this.URL + 'resources');
  }
}
