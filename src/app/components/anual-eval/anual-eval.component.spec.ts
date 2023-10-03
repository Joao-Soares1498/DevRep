import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnualEvalComponent } from './anual-eval.component';

describe('AnualEvalComponent', () => {
  let component: AnualEvalComponent;
  let fixture: ComponentFixture<AnualEvalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AnualEvalComponent]
    });
    fixture = TestBed.createComponent(AnualEvalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
