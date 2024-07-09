import {ApplicationConfig, importProvidersFrom} from '@angular/core';

import {AngularYandexMapsModule, YaConfig} from "angular8-yandex-maps";

const config: YaConfig = {
  apikey: '1292027b-f551-4323-9f84-246274aa2b33',
};
export const appConfig: ApplicationConfig = {
  providers :[importProvidersFrom(AngularYandexMapsModule.forRoot(config))]
};

