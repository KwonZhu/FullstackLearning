import { Navigate } from 'react-router-dom';

interface ProtectedRouteProps {
  isAuthenticated: boolean;
  children: React.ReactNode;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ isAuthenticated, children }) => {
  if (isAuthenticated) {
    return children;
  }
  return <Navigate to="/login" />;
};
export default ProtectedRoute;
