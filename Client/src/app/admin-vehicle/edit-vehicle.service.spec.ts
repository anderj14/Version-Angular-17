import { TestBed } from '@angular/core/testing';

import { EditVehicleService } from './edit-vehicle.service';

describe('EditVehicleService', () => {
  let service: EditVehicleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditVehicleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
