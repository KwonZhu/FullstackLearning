import logo from './logo.svg';
import './App.css';
import CourseCard from './components/CourseCard/CourseCard';
import React, { useState } from 'react';

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

  // // Requires the title to exactly match the search query, partial matches won’t work
  // const displayCourses = courses.filter((course) => course.title.toLowerCase() === searchQuery.toLowerCase());

  // Substring Match allows for partial matching
  const displayCourses = courses.filter((course) => course.title.toLowerCase().includes(searchQuery.toLowerCase()));
  return (
    <div className="App">
      {/* search */}
      <input
        type="text"
        placeholder="search for courses by title"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      ></input>

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
