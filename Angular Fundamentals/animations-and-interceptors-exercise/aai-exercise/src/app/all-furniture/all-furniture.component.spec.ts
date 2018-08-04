import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllFurnitureComponent } from './all-furniture.component';

describe('AllFurnitureComponent', () => {
  let component: AllFurnitureComponent;
  let fixture: ComponentFixture<AllFurnitureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllFurnitureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllFurnitureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
