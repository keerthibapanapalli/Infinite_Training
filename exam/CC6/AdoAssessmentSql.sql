
create table students (
    studentid int identity primary key,
       fullname varchar(100) not null,
    email varchar(100) unique,
    department varchar(50) not null,
    yearofstudy int not null
)

create table courses (
    courseid int identity primary key,
    coursename varchar(100) not null,
    credits int not null,
    semester varchar(20) not null
)

create table enrollments (
    enrollmentid int identity primary key,
    studentid int foreign key references students(studentid),
    courseid int foreign key references courses(courseid),
    enrolldate datetime not null,
    grade varchar(5) null
)


insert into students (fullname,email,department,yearofstudy) values
('rahul','rahulkumar@example.com','cse',2),
('ananya','ananyareddy@example.com','ece',3),
('shailu','shailaja@example.com','mechanical',1),
('keerthi','keerthi.b@example.com','IT', 2),
('chaitu','chaitanyakrishna@example.com','civil',4);


insert into courses (coursename,credits,semester) values
('dsa',4,'summer'),
('dbms',5,'spring'),
('os',3,'winter'),
('cloud',3,'spring'),
('cyber security',5,'winter'),
('data science',4,'summer')

insert into enrollments(studentid, courseid, enrolldate, grade) values
(1,4, '2025-08-10','A'), 
(2,3,'2025-02-12','B'),
(3,2,'2025-08-15','A'),
(4,5,'2025-06-22','C'),
(5,1,'2025-10-27','B')


select studentid, fullname from students
select courseid, coursename from courses
select * from courses
select * from students

create procedure usp_GetCoursesBySemester
@semester nvarchar(50)
as begin
set nocount on;
 select CourseId, CourseName, Credits, Semester from Courses where Semester = @semester;
end
exec usp_GetCoursesBySemester @semester = 'summer'