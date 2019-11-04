import { TestBed } from '@angular/core/testing';

import { LinqChallengeService } from './linq-challenge.service';

describe('LinqChallengeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LinqChallengeService = TestBed.get(LinqChallengeService);
    expect(service).toBeTruthy();
  });
});
