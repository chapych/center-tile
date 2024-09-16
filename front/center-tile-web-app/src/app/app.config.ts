import {ApplicationConfig, importProvidersFrom} from '@angular/core';

import {AngularYandexMapsModule, YaConfig} from "angular8-yandex-maps";
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { YANDEX_API_KEY } from '../utils/constants';
import { provideHttpClient } from '@angular/common/http';


const config: YaConfig = {
  apikey: YANDEX_API_KEY,
};
export const appConfig: ApplicationConfig = {
  providers :[importProvidersFrom(AngularYandexMapsModule.forRoot(config)), provideAnimationsAsync(), provideHttpClient()]
};

