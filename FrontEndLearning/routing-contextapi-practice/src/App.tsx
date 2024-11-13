import { Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import CourseListPage from './pages/CourseListPage';
import NavBar from './components/NavBar';
import UserProfilePage from './pages/UserProfilePage';
import LoginPage from './pages/LoginPage';
import ProtectedRoute from './components/ProtectedRoute';

const isAuthenticated = true;

const App = () => {
  return (
    <div>
      <NavBar />
      <div className="main-content">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/courses" element={<CourseListPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route
            path="/profile/*"
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated}>
                <UserProfilePage />
              </ProtectedRoute>
            }
          ></Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
