import React, { useState } from 'react';
import styled from 'styled-components';

const Card = styled.div`
  width: 350px;
  height: 500px;
  background-color: lightblue;
  margin: 0 auto;
  &:hover {
    background-color: pink;
  }
`;

const CourseCard = ({ title, price, language, duration, location, isNew, difficulty }) => {
  const [isEnrolled, setIsEnrolled] = useState(false);
  const [isReviewed, setIsReviewed] = useState(false);
  const [isReviewSubmitted, setIsReviewSubmitted] = useState(false);
  const [enrollCount, setEnrollCount] = useState(0);

  const handleIsEnrolledChange = () => {
    setIsEnrolled(true);
  };

  const handleIsReviewedChange = () => {
    setIsReviewed(true);
  };

  const handleIsReviewSubmittedChange = (e) => {
    e.preventDefault();
    setIsReviewSubmitted(true);
  };

  const handleEnrollCountChange = () => {
    handleIsEnrolledChange();
    setEnrollCount(enrollCount + 1);
  };

  const enrollText = difficulty === 'Beginner' ? 'Start Learning Now!' : 'Enroll Now';

  return (
    <Card>
      <p>Course: {title}</p>
      <p>Price: {price}</p>
      <p>Language: {language}</p>
      <p>Duration: {duration}</p>
      <p>Location: {location}</p>
      {isNew && <p>New Course</p>}
      <p>Level: {difficulty}</p>

      {/* Enroll and count courses */}
      <button onClick={handleEnrollCountChange}>{enrollText}</button>
      <p>Enrolled: {enrollCount > 0 ? `${enrollCount} courses` : '0 course'}</p>

      {/* Review */}
      {isEnrolled && (
        <div>
          {!isReviewed && <button onClick={handleIsReviewedChange}>Leave a Review</button>}
          {isReviewed && (
            <form onSubmit={handleIsReviewSubmittedChange}>
              <textarea cols={20} rows={5}></textarea>
              <button type="submit">{isReviewSubmitted ? 'Review Submitted' : 'Submit'}</button>
            </form>
          )}
        </div>
      )}
    </Card>
  );
};
export default CourseCard;
