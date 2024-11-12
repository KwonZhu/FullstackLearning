import { Course } from '../../types/Course';

const CourseCard = ({ title, description, lessons }: Course) => {
  return (
    <div className="course-card">
      <h3>{title}</h3>
      <p>{description}</p>
      <p>Lessons: {lessons}</p>
    </div>
  );
};
export default CourseCard;
