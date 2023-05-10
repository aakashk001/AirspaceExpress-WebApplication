import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageNotFindComponent } from './page-not-find.component';

describe('PageNotFindComponent', () => {
  let component: PageNotFindComponent;
  let fixture: ComponentFixture<PageNotFindComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageNotFindComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageNotFindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
