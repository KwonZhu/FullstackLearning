import { Link, Outlet } from 'react-router-dom';

const UserProfilePage = () => {
  return (
    <div>
      <h2>User Profile</h2>
      <ul>
        <li>
          <Link to="settings">Settings</Link>
        </li>
        <li>
          <Link to="orders">Orders</Link>
        </li>
      </ul>
      <Outlet />
    </div>
  );
};
export default UserProfilePage;
