import React, { Component } from 'react';
import styled from 'styled-components';

const Card = styled.div`
  width: 300px;
  height: 300px;
  background-color: lightblue;
  margin: 0 auto;
`;
const CourseCard = ({ title, price, language, duration, location, isNew }) => {
  return (
    <Card>
      <h2>Course: {title}</h2>
      <h2>Price: {price}</h2>
      <h2>Language: {language}</h2>
      <h2>Duration: {duration}</h2>
      <h2>Location: {location}</h2>
      {isNew && <h2>New</h2>}
    </Card>
  );
};
export default CourseCard;

// class component
// class CourseCard extends Component {
//   render() {
//     const { title, price, language, duration, location, isNew } = this.props;
//     return (
//       <Card>
//         <h2>Course: {title}</h2>
//         <h2>Price: {price}</h2>
//         <h2>Language: {language}</h2>
//         <h2>Duration: {duration}</h2>
//         <h2>Location: {location}</h2>
//         {isNew && <h2>New</h2>}
//       </Card>
//     );
//   }
// }
// export default CourseCard;
