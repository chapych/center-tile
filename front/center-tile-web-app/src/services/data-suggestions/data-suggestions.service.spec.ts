import { TestBed } from '@angular/core/testing';

import { DataSuggestionsService } from './data-suggestions.service';

describe('DataSuggestionsService', () => {
  let service: DataSuggestionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataSuggestionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
