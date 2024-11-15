// Test HomePage Component
// 1. This component should render an h1 element with Home heading
// 2. This component should render a p element with a welcome message
import HomePage from './HomePage';
import { render, screen } from '@testing-library/react';

describe('HomePage Component', () => {
  it('should render Home heading when render correctly', () => {
    render(<HomePage />);
    const headingElement = screen.getByRole('heading', { name: /Home/i });
    //screen.getByText(/Home/i): Found multiple elements with the text: /Home/i
    expect(headingElement).toBeInTheDocument();
  });

  it('should render Welcome message when render correctly', () => {
    render(<HomePage />);
    const paragraphElement = screen.getByText(/Welcome to the HomePage/i);
    expect(paragraphElement).toBeInTheDocument();
  });
});
