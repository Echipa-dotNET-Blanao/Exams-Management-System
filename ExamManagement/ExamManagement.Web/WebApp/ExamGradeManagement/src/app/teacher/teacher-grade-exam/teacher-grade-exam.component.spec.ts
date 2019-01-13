import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherGradeExamComponent } from './teacher-grade-exam.component';

describe('TeacherGradeExamComponent', () => {
  let component: TeacherGradeExamComponent;
  let fixture: ComponentFixture<TeacherGradeExamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherGradeExamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherGradeExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
