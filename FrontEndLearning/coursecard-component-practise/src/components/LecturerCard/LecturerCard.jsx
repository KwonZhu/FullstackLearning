import React from 'react';
import styled from 'styled-components';

const Card = styled.div`
  width: 350px;
  height: 200px;
  background-color: pink;
  margin: 0 auto;
  &:hover {
    background-color: lightblue;
`;

const LecturerCard = ({ name, title }) => {
  return (
    <Card>
      <p>name: {name}</p>
      <p>title: {title}</p>
    </Card>
  );
};
export default LecturerCard;
