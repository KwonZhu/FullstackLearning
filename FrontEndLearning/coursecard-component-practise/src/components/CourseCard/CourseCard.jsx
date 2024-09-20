import React, { useState } from 'react';
import styled from 'styled-components';

const Card = styled.div`
  width: 250px;
  height: 500px;
  background-color: lightblue;
  margin: 0 auto;
  &:hover {
    background-color: pink;
  }
`;

const CourseCard = ({ data, handleIsFavoriteChange }) => {
  const { id, title, price, language, duration, location, isNew, difficulty, isCompleted, isFavorite } = data;

  const [isEnrolled, setIsEnrolled] = useState(false);
  const [isShowInput, setIsShowInput] = useState(true);
  const [enrollCount, setEnrollCount] = useState(0);

  const handleIsEnrolledChange = () => {
    setIsEnrolled(true);
    setEnrollCount((prevEnrollCount) => prevEnrollCount + 1);
  };

  const handleIsShowInputChange = () => {
    setIsShowInput(false);
  };

  const enrollText = difficulty === 'Beginner' ? 'Start Learning Now!' : 'Enroll Now';
  const enrollCountText = enrollCount > 0 ? `${enrollCount} courses` : '0 course';
  const courseCompleteText = isCompleted ? 'Revisit Course' : 'Start Course';
  const isFavoriteText = isFavorite ? 'Unfavorite' : 'Favorite';

  return (
    <Card>
      <p>
        Course: {title}
        {isFavorite && <span>⭐</span>}
      </p>
      <p>Price: {price}</p>
      <p>Language: {language}</p>
      <p>Duration: {duration}</p>
      <p>Location: {location}</p>
      {isNew && <p>New Course</p>}
      <p>Level: {difficulty}</p>

      {/* Enroll and count courses */}
      <button onClick={handleIsEnrolledChange}>{enrollText}</button>
      <p>Enrolled: {enrollCountText}</p>

      {/* Review */}
      {isEnrolled && (
        <div>
          {isShowInput && <input type="text" placeholder="Leave your review"></input>}
          {<button onClick={handleIsShowInputChange}>Submit</button>}
          {/* course completion */}
          <button>{courseCompleteText}</button>
          {/* add to Favorite */}
          <button onClick={() => handleIsFavoriteChange(id)}>{isFavoriteText}</button>
        </div>
      )}
    </Card>
  );
};
export default CourseCard;
