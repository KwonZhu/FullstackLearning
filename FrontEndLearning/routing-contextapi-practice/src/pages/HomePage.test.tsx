// Test HomePage Component
// 1. This component should render an h1 element with Home heading
// 2. This component should render a p element with a welcome message
import HomePage from './HomePage';
import { render, screen } from '@testing-library/react';

describe('HomePage Component', () => {
  it('should render Home heading correctly', () => {
    // Act: Render the CourseCard component
    render(<HomePage />);

    // Assert: Check if the heading is rendered correctly
    const headingElement = screen.getByRole('heading', { name: /Home/i });
    //screen.getByText(/Home/i): Found multiple elements with the text: /Home/i
    expect(headingElement).toBeInTheDocument();

    // Assert: Check if the paragraph is rendered correctly
    const paragraphElement = screen.getByText(/Welcome to the HomePage/i);
    expect(paragraphElement).toBeInTheDocument();
  });
});
