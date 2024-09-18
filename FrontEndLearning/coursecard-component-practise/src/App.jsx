import logo from './logo.svg';
import './App.css';
import CourseCard from './components/CourseCard/CourseCard';
import React, { useState, useEffect } from 'react';
import LecturerCard from './components/LecturerCard/LecturerCard';

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
  },
];

function App() {
  const [searchQuery, setSearchQuery] = useState('');
  const [lecturers, setLecturers] = useState([]);

  // // Requires the title to exactly match the search query, partial matches won’t work
  // const displayCourses = courses.filter((course) => course.title.toLowerCase() === searchQuery.toLowerCase());

  // Substring Match allows for partial matching
  const displayCourses = courses.filter((course) => course.title.toLowerCase().includes(searchQuery.toLowerCase()));

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
  useEffect(() => {
    const fetchLecturers = async () => {
      try {
        const response = await fetch('https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers');
        if (!response.ok) {
          throw new Error('Fail to fetch lecturers');
        }
        const data = await response.json();
        setLecturers(data);
      } catch (error) {
        console.error('Error fetching data');
      }
    };
    fetchLecturers();
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
        onChange={(e) => setSearchQuery(e.target.value)}
      ></input>

      {/* display searched courses */}
      {displayCourses.map((course) => (
        <CourseCard data={course} key={course.id} />
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
