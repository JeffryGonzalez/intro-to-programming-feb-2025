import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ResourceStore } from '../services/resource.store';

@Component({
  selector: 'app-resource-filter-2',
  imports: [RouterLink],
  changeDetection: ChangeDetectionStrategy.OnPush,

  template: `
    <div class="grid gap-2 grid-flow-col ">
      @for (tag of store.tags(); track tag) {
        <div
          class="badge badge-secondary badge-outline hover:badge-lg badge-lg  h-16"
        >
          <a [routerLink]="['.']" [queryParams]="{ filter: tag }">{{ tag }}</a>
        </div>
      }
    </div>
  `,
  styles: ``,
})
export class FilterComponent {
  store = inject(ResourceStore);
  router = inject(Router);
  changeTheFilter(event: any): void {
    // big old code smell here, yo.
    this.router.navigate([], {
      queryParams: { filter: event.target.value },
    });
  }
}
