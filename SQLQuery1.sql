select DISTINCT FirstName,LastName,ID
from Instructor,LessonAssigment,Lesson,Enrollment
where Instructor.ID = LessonAssigment.InstructorID 
and LessonAssigment.LessonID = Lesson.LessonID
and Lesson.LessonID = Enrollment.LessonID