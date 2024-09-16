import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoverInfoComponent } from './cover-info.component';

describe('CoverInfoComponent', () => {
  let component: CoverInfoComponent;
  let fixture: ComponentFixture<CoverInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CoverInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CoverInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
