import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryDatailsComponent } from './summary-datails.component';

describe('SummaryDatailsComponent', () => {
  let component: SummaryDatailsComponent;
  let fixture: ComponentFixture<SummaryDatailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SummaryDatailsComponent]
    });
    fixture = TestBed.createComponent(SummaryDatailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
