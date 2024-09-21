import logo from './logo.svg';
import './App.css';
import CourseCard from './components/CourseCard/CourseCard';
import React, { useState, useEffect } from 'react';
import LecturerCard from './components/LecturerCard/LecturerCard';
import axios from 'axios';

const courses = [
  {
    id: 1,
    title: 'React',
    price: '$1',
    language: 'EN',
    duration: '2 hours',
    location: 'Sydney',
    isNew: true,
    difficulty: 'Beginner',
    isCompleted: false,
    isFavorite: false,
  },
  {
    id: 2,
    title: '.Net',
    price: '$2',
    language: 'EN',
    duration: '5 hours',
    location: 'Melbourne',
    isNew: false,
    difficulty: 'Intermediate',
    isCompleted: true,
    isFavorite: false,
  },
  {
    id: 3,
    title: 'NodeJS',
    price: '$3',
    language: 'EN',
    duration: '10 hours',
    location: 'Melbourne',
    isNew: true,
    difficulty: 'Advanced',
    isCompleted: true,
    isFavorite: false,
  },
];

function App() {
  const [myCourses, setMyCourses] = useState(courses);
  const [searchQuery, setSearchQuery] = useState('');
  const [lecturers, setLecturers] = useState([]);

  const handleIsFavoriteChange = (courseId) => {
    const newCourses = myCourses.map((course) => {
      if (course.id === courseId) {
        course.isFavorite = !course.isFavorite;
      }
      return course;
    });
    setMyCourses(newCourses);
  };

  const handleSearchQueryChange = (event) => {
    setSearchQuery(event.target.value);
  };

  // // Requires the title to exactly match the search query, partial matches won’t work. Not user friendly
  // const displayCourses = courses.filter((course) => course.title.toLowerCase() === searchQuery.toLowerCase());

  // Substring Match allows for partial matching (eg 're' can match 'React')
  const displayCourses = myCourses.filter((course) => course.title.toLowerCase().includes(searchQuery.toLowerCase()));

  // use fetch() with Promises to get lecturers from remote
  // useEffect(() => {
  //   fetch('https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers')
  //     .then((response) => response.json())
  //     .then((data) => {
  //       setLecturers(data);
  //     })
  //     .catch((error) => {
  //       console.error('Error fetching data:', error);
  //     });
  // }, []);

  // use async/await to fetch
  // useEffect(() => {
  //   const fetchLecturers = async () => {
  //     try {
  //       const response = await fetch('https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers');
  //       // Check if the response is OK (status 200-299)
  //       if (!response.ok) {
  //         throw new Error('Fail to fetch lecturers');
  //       }
  //       const data = await response.json();
  //       setLecturers(data);
  //     } catch (error) {
  //       console.error('fetch error', error);
  //     }
  //   };
  //   fetchLecturers();
  // }, []);

  // Using Axios with async/await
  useEffect(() => {
    const axiosLecturers = async () => {
      try {
        const response = await axios.get('https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers');
        setLecturers(response.data);
      } catch (error) {
        console.error('axios error', error);
      }
    };
    axiosLecturers();
  }, []);

  return (
    <div className="App">
      {/* display lecturers */}
      {lecturers.map((lecturer) => (
        <LecturerCard name={lecturer.name} title={lecturer.title} key={lecturer.id} />
      ))}

      {/* search courses*/}
      <input
        type="text"
        placeholder="search for courses by title"
        value={searchQuery}
        onChange={handleSearchQueryChange}
      />

      {/* display searched courses */}
      {displayCourses.map((course) => (
        <CourseCard data={course} key={course.id} handleIsFavoriteChange={handleIsFavoriteChange} />
      ))}
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a className="App-link" href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;

// import CourseCard from './components/CourseCard/CourseCard';
// import React, { useState, useEffect } from 'react';
// const courses = [
//   {
//     id: 1,
//     title: 'React',
//     price: '$1',
//     language: 'EN',
//     duration: '2 hours',
//     location: 'Sydney',
//     isNew: true,
//     difficulty: 'Beginner',
//     isCompleted: false,
//     isFavorite: false,
//   },
//   {
//     id: 2,
//     title: '.Net',
//     price: '$2',
//     language: 'EN',
//     duration: '5 hours',
//     location: 'Melbourne',
//     isNew: false,
//     difficulty: 'Intermediate',
//     isCompleted: true,
//     isFavorite: false,
//   },
//   {
//     id: 3,
//     title: 'NodeJS',
//     price: '$3',
//     language: 'EN',
//     duration: '10 hours',
//     location: 'Melbourne',
//     isNew: true,
//     difficulty: 'Advanced',
//     isCompleted: true,
//     isFavorite: false,
//   },
// ];

// function App() {
//   const [myCourses, setMyCourses] = useState(courses);
//   const handleIsFavoriteChange = (courseId) => {
//     const newCourses = myCourses.map((course) => {
//       if (course.id === courseId) {
//         course.isFavorite = !course.isFavorite;
//       }
//       return course;
//     });
//     setMyCourses(newCourses);
//   };
//   return (
//     <div className="App">
//        {myCourses.map((course) => (
//         <CourseCard data={course} key={course.id} handleIsFavoriteChange={handleIsFavoriteChange} />
//       ))}
//        </div>
//   );
// }

// export default App;
