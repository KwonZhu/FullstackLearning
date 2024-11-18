import { render, screen, fireEvent } from '@testing-library/react';
import LoginPage from './LoginPage';

describe('LoginPage Component', () => {
  it('should render login form with username and password inputs and a submit button', () => {
    render(<LoginPage onSubmit={jest.fn()} />);

    // Check if the username input is in the document
    expect(screen.getByLabelText(/username/i)).toBeInTheDocument();

    // Check if the password input is in the document
    expect(screen.getByLabelText(/password/i)).toBeInTheDocument();

    // Check if the login button is in the document
    expect(screen.getByRole('button', { name: /login/i })).toBeInTheDocument();
  });

  it('should allow user to type into username and password inputs', () => {
    render(<LoginPage onSubmit={jest.fn()} />);

    // Type into the username input
    const usernameInput = screen.getByLabelText(/username/i);
    fireEvent.change(usernameInput, { target: { value: 'testuser' } });

    expect(usernameInput).toHaveValue('testuser');

    // Type into the password input
    const passwordInput = screen.getByLabelText(/password/i);
    fireEvent.change(passwordInput, { target: { value: 'password123' } });

    expect(passwordInput).toHaveValue('password123');
  });

  it('should call onSubmit with username and password when form is submitted', () => {
    const mockOnSubmit = jest.fn();
    render(<LoginPage onSubmit={mockOnSubmit} />);

    // Type values into the inputs
    fireEvent.change(screen.getByLabelText(/username/i), { target: { value: 'testuser' } });
    fireEvent.change(screen.getByLabelText(/password/i), { target: { value: 'password123' } });

    // Click the login button to submit the form
    fireEvent.click(screen.getByRole('button', { name: /login/i }));

    // Check if mockOnSubmit was called with the correct values
    expect(mockOnSubmit).toHaveBeenCalledWith('testuser', 'password123');
    expect(mockOnSubmit).toHaveBeenCalledTimes(1);
  });
});
