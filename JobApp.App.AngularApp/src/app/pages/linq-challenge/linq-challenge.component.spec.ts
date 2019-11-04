import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinqChallengeComponent } from './linq-challenge.component';

describe('LinqChallengeComponent', () => {
  let component: LinqChallengeComponent;
  let fixture: ComponentFixture<LinqChallengeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinqChallengeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinqChallengeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
