import { render, screen } from '@testing-library/react';
import CourseCard from './CourseCard';

describe('CourseCard Component', () => {
  it('should render title, description and lessons correctly', () => {
    // Arrange: Create a sample course object
    const course = {
      id: 1,
      title: 'Redux Basic',
      description: 'This is not easy',
      lessons: 10,
    };

    // Act: Render the CourseCard component with the course props
    render(<CourseCard {...course} />);

    // Assert: Check if the title is rendered correctly
    const titleElement = screen.getByText(/Redux Basic/i);
    expect(titleElement).toBeInTheDocument();

    // Assert: Check if the description is rendered correctly
    const descriptionElement = screen.getByText(/This is not easy/i);
    expect(descriptionElement).toBeInTheDocument();

    // Assert: Check if the lessons count is rendered correctly
    const lessonsElement = screen.getByText(/Lessons: 10/i);
    expect(lessonsElement).toBeInTheDocument();
  });
});
