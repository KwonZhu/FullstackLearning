import { useParams } from 'react-router-dom';

const CourseDeatilsPage = () => {
  const { courseId } = useParams();
  return <div>Details for course {courseId}</div>;
};
export default CourseDeatilsPage;
