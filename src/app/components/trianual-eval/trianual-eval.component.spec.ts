import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrianualEvalComponent } from './trianual-eval.component';

describe('TrianualEvalComponent', () => {
  let component: TrianualEvalComponent;
  let fixture: ComponentFixture<TrianualEvalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrianualEvalComponent]
    });
    fixture = TestBed.createComponent(TrianualEvalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
