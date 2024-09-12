import logo from './logo.svg';
import './App.css';
import CourseCard from './components/CourseCard/CourseCard';

function App() {
  return (
    <div className="App">
      <CourseCard
        title="React"
        price="$1"
        language="EN"
        duration="1h"
        location="Sydney"
        isNew={true}
        difficulty="Beginner"
      />
      <CourseCard
        title=".Net"
        price="$2"
        language="EN"
        duration="1h"
        location="Melbourne"
        isNew={false}
        difficulty="Intermediate"
      />
      <CourseCard
        title="NodeJS"
        price="$3"
        language="EN"
        duration="1h"
        location="Melbourne"
        isNew={true}
        difficulty="Advanced"
      />
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
