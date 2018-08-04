import { TestBed, inject } from '@angular/core/testing';

import { FurnitureService } from './furniture.service';

describe('FurnitureService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FurnitureService]
    });
  });

  it('should be created', inject([FurnitureService], (service: FurnitureService) => {
    expect(service).toBeTruthy();
  }));
});
