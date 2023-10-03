import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewEvalComponent } from './new-eval.component';

describe('NewEvalComponent', () => {
  let component: NewEvalComponent;
  let fixture: ComponentFixture<NewEvalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewEvalComponent]
    });
    fixture = TestBed.createComponent(NewEvalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
