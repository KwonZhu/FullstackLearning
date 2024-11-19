import { render, screen, fireEvent } from '@testing-library/react';
import LoginPage from './LoginPage';

describe('LoginPage Component', () => {
  const mockOnSubmit = jest.fn();

  beforeEach(() => {
    jest.clearAllMocks();
  });

  it('should render login form with username and password inputs and a submit button', () => {
    render(<LoginPage onSubmit={mockOnSubmit} />);

    // Check if the username input is in the document
    expect(screen.getByLabelText(/username/i)).toBeInTheDocument();

    // Check if the password input is in the document
    expect(screen.getByLabelText(/password/i)).toBeInTheDocument();

    // Check if the login button is in the document
    expect(screen.getByRole('button', { name: /login/i })).toBeInTheDocument();
  });

  it('should allow user to type into username and password inputs', () => {
    render(<LoginPage onSubmit={mockOnSubmit} />);

    const usernameInput = screen.getByLabelText(/username/i) as HTMLInputElement;
    const passwordInput = screen.getByLabelText(/password/i) as HTMLInputElement;

    // Act fill in the form fields
    fireEvent.change(usernameInput, { target: { value: 'testuser' } });
    fireEvent.change(passwordInput, { target: { value: 'password123' } });

    expect(usernameInput).toHaveValue('testuser');
    expect(passwordInput.value).toBe('password123');
  });

  it('should call onSubmit with username and password when form is submitted', () => {
    render(<LoginPage onSubmit={mockOnSubmit} />);

    const submitButton = screen.getByRole('button', { name: /login/i });

    // Type values into the inputs
    fireEvent.change(screen.getByLabelText(/username/i), { target: { value: 'testuser' } });
    fireEvent.change(screen.getByLabelText(/password/i), { target: { value: 'password123' } });

    // Click the login button to submit the form
    fireEvent.click(submitButton);

    // Check if mockOnSubmit was called with the correct values
    expect(mockOnSubmit).toHaveBeenCalledWith('testuser', 'password123');
    expect(mockOnSubmit).toHaveBeenCalledTimes(1);
  });

  it('prevents form submission if username or password is empty', () => {
    render(<LoginPage onSubmit={mockOnSubmit} />);

    const submitButton = screen.getByRole('button', { name: /login/i });

    // Submit the form without entering any input
    fireEvent.click(submitButton);

    // onSubmit should not be called since the inputs are empty
    expect(mockOnSubmit).not.toHaveBeenCalled();
  });
});
