import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectEvComponent } from './select-ev.component';

describe('SelectEvComponent', () => {
  let component: SelectEvComponent;
  let fixture: ComponentFixture<SelectEvComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectEvComponent]
    });
    fixture = TestBed.createComponent(SelectEvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
