import React, { useState } from 'react';
import './style.css';

// const name = 'Bob';
// const isLoggedIn = true;

// if-else version
// function CourseCard() {
//   if (isLoggedIn) {
//     return (
//       <div>
//         <h1>Hello, {name}</h1>
//         <p>Welcome back!</p>
//       </div>
//     );
//   } else {
//     return (
//       <div>
//         <h1>Hello, {name}</h1>
//         <p>Please sign in</p>
//       </div>
//     );
//   }
// }

// ternary operator version
// function CourseCard() {
//   return (
//     <div>
//       <h1>Hello, {name}</h1>
//       <p>{isLoggedIn ? `Welcome back! ${name}` : 'Please sign in'}</p>
//     </div>
//   );
// }

// inline styling
// function CourseCard() {
//   const styles = {
//     backgroundColor: 'lightblue',
//     fontSize: '30px',
//   };
//   return (
//     <div style={styles}>
//       <h1>Hello, {name}</h1>
//       <p>{isLoggedIn ? `Welcome back! ${name}` : 'Please sign in'}</p>
//     </div>
//   );
// }

//css class
// function CourseCard() {
//   return (
//     <div className="my-class">
//       <h1>Hello, {name}</h1>
//       <p>{isLoggedIn ? `Welcome back! ${name}` : 'Please sign in'}</p>
//     </div>
//   );
// }

// props
// function CourseCard(props) {
//   return (
//     <div className="my-class">
//       <h2>{props.title}</h2>
//       <p>{props.description}</p>
//       <p>{props.lessons} lectures</p>
//     </div>
//   );
// }

// state
function CourseCard(props) {
  const [isEnrolled, setIsEnrolled] = useState(false);

  const handleEnroll = () => {
    setIsEnrolled(true);
  };

  return (
    <div className="my-class">
      <h2>{props.title}</h2>
      <p>{props.description}</p>
      <p>{props.lessons} lectures</p>

      <button onClick={handleEnroll} disabled={isEnrolled}>
        {isEnrolled ? 'Enrolled' : 'Enroll now'}
      </button>
    </div>
  );
}
export default CourseCard;
