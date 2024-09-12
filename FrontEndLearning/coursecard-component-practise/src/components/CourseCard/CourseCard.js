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
  const [isReviewed, setIsReviewed] = useState(false);
  const [isReviewSubmitted, setIsReviewSubmitted] = useState(false);

  const handleIsReviewedChange = () => {
    setIsReviewed(true);
  };

  const handleIsReviewSubmittedChange = () => {
    setIsReviewSubmitted(true);
  };

  return (
    <Card>
      <p>Course: {title}</p>
      <p>Price: {price}</p>
      <p>Language: {language}</p>
      <p>Duration: {duration}</p>
      <p>Location: {location}</p>
      {isNew && <p>New Course</p>}
      <p>Level: {difficulty}</p>
      <button>{difficulty === 'Beginner' ? 'Start Learning Now!' : 'Enroll Now'}</button>

      {/* Review */}
      {!isReviewed && <button onClick={handleIsReviewedChange}>Leave a Review</button>}
      {isReviewed && (
        <form onSubmit={handleIsReviewSubmittedChange}>
          <textarea cols={20} rows={5}></textarea>
          <button type="submit">{isReviewSubmitted ? 'Review Submitted' : 'Submit'}</button>
        </form>
      )}
    </Card>
  );
};
export default CourseCard;
