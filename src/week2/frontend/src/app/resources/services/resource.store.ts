import { patchState, signalStore, withHooks, withMethods } from '@ngrx/signals';
import { addEntities, withEntities } from '@ngrx/signals/entities';
import { ResourceListItem } from '../types';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { pipe, switchMap, tap } from 'rxjs';
import { ResourceDataService } from './resource-data.service';
import { inject } from '@angular/core';

export const ResourceStore = signalStore(
  withEntities<ResourceListItem>(),
  withMethods((store) => {
    const service = inject(ResourceDataService);
    return {
      _load: rxMethod<void>(
        pipe(
          switchMap(() =>
            service
              .getResource()
              .pipe(tap((r) => patchState(store, addEntities(r)))),
          ),
        ),
      ),
    };
  }),
  withHooks({
    onInit(store) {
      store._load();
    },
  }),
);
