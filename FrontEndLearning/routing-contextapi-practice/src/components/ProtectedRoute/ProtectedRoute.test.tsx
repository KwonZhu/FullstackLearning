import ProtectedRoute from './ProtectedRoute';
import { render, screen } from '@testing-library/react';
import { useAuth } from '../../context/AuthContext';
import { MemoryRouter, Routes, Route } from 'react-router-dom';

// mock AuthContext module
jest.mock('../../context/AuthContext', () => ({
  useAuth: jest.fn(),
}));

// mock components
const MockProtectedPage = () => <div>Protected Content</div>;
const MockLoginPage = () => <div>Login Content</div>;

describe('ProtectedRoute Component', () => {
  it('should redirect to login page if user is not authenticated', () => {
    // Mock the authentication hook to return isAuthenticated: false
    (useAuth as jest.Mock).mockReturnValue({ isAuthenticated: false });

    // Arrange: Render the ProtectedRoute within a MemoryRouter with initial routes
    render(
      <MemoryRouter initialEntries={['/profile']}>
        <Routes>
          <Route path="/login" element={<MockLoginPage />} />
          <Route
            path="/profile"
            element={
              <ProtectedRoute>
                <MockProtectedPage />
              </ProtectedRoute>
            }
          />
        </Routes>
      </MemoryRouter>
    );

    // Assert: User should be redirected to the login page
    const LoginElement = screen.getByText(/Login Content/i);
    expect(LoginElement).toBeInTheDocument();
  });

  it('should render the protected page if user is authenticated', () => {
    // Mock the authentication hook to return isAuthenticated: true
    (useAuth as jest.Mock).mockReturnValue({ isAuthenticated: true });

    // Arrange: Render the ProtectedRoute within a MemoryRouter with initial routes
    render(
      <MemoryRouter initialEntries={['/profile']}>
        <Routes>
          <Route
            path="/profile"
            element={
              <ProtectedRoute>
                <MockProtectedPage />
              </ProtectedRoute>
            }
          />
        </Routes>
      </MemoryRouter>
    );

    // Assert: Protected page should be displayed
    const ProtectedElement = screen.getByText(/Protected Content/i);
    expect(ProtectedElement).toBeInTheDocument();
  });
});
