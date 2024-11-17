import { useParams } from 'react-router-dom';

const CourseDetailsPage = () => {
  const { courseId } = useParams();
  return <div>Details for course {courseId}</div>;
};
export default CourseDetailsPage;
