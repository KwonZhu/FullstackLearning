import React from 'react';
// import styled from 'styled-components';
import styled from 'styled-components';
const Card = styled.div`
  width: 300px;
  height: 300px;
  background-color: lightblue;
`;
function CourseCard({ title, price, language, duration, location }) {
  return (
    <Card>
      <h2>Course: {title}</h2>
      <h2>Price: {price}</h2>
      <h2>Language: {language}</h2>
      <h2>Duration: {duration}</h2>
      <h2>Location: {location}</h2>
    </Card>
  );
}
export default CourseCard;
