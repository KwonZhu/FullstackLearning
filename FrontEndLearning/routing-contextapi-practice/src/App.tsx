import { Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import CourseListPage from './pages/CourseListPage';
import NavBar from './components/NavBar';
import UserProfilePage from './pages/UserProfilePage';

const App = () => {
  return (
    <div>
      <NavBar />
      <div className="main-content">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/courses" element={<CourseListPage />} />
          <Route path="/profile" element={<UserProfilePage />} />
        </Routes>
      </div>
    </div>
  );
};

export default App;
