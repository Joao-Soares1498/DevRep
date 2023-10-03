import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyEvalComponent } from './my-eval.component';

describe('MyEvalComponent', () => {
  let component: MyEvalComponent;
  let fixture: ComponentFixture<MyEvalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyEvalComponent]
    });
    fixture = TestBed.createComponent(MyEvalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
