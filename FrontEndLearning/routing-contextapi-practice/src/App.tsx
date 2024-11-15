import { Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import CourseListPage from './pages/CourseListPage';
import NavBar from './components/NavBar';
import UserProfilePage from './pages/UserProfilePage';
import LoginPage from './pages/LoginPage';
import ProtectedRoute from './components/ProtectedRoute';
import CourseDetailsPage from './pages/CourseDetailsPage';
import Settings from './components/Settings';
import Orders from './components/Orders';

const App = () => {
  return (
    <div>
      <NavBar />
      <div className="main-content">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/courses" element={<CourseListPage />} />
          <Route path="/courses/:courseId" element={<CourseDetailsPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route
            path="/profile/*"
            element={
              <ProtectedRoute>
                <UserProfilePage />
              </ProtectedRoute>
            }>
            <Route path="settings" element={<Settings />} />
            <Route path="orders" element={<Orders />} />
          </Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
