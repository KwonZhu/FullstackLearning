import CourseCard from '../components/CourseCard';
import { useCourses } from '../hooks/useCourses';
const CourseListPage = () => {
  const { courses, loading, error } = useCourses();

  if (loading) {
    return <div>Loading...</div>;
  }
  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="course-list">
      {courses.map((course) => (
        <CourseCard key={course.id} {...course} />
      ))}
    </div>
  );
};
export default CourseListPage;
