import { Link } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';

const NavBar = () => {
  const { isAuthenticated, toggleAuth } = useAuth();

  return (
    <nav className="navbar">
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/courses">Courses</Link>
        </li>
        {isAuthenticated && (
          <li>
            <Link to="/profile">Profile</Link>
          </li>
        )}
        <li>
          <button onClick={toggleAuth}>{isAuthenticated ? 'Logout' : 'Login'}</button>
        </li>
      </ul>
    </nav>
  );
};
export default NavBar;
