import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyFurnitureComponent } from './my-furniture.component';

describe('MyFurnitureComponent', () => {
  let component: MyFurnitureComponent;
  let fixture: ComponentFixture<MyFurnitureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyFurnitureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyFurnitureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
