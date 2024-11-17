import { render, screen } from '@testing-library/react';
import CourseDetailsPage from './CourseDetailsPage';
import { MemoryRouter, Route, Routes } from 'react-router-dom';

describe('CourseDetailsPage Component', () => {
  it('should display the courseId from the url', () => {
    //Arrange: Render the CourseDetailsPage within a MemoryRouter with a specific initial route
    render(
      <MemoryRouter initialEntries={['/courses/123']}>
        <Routes>
          <Route path="/courses/:courseId" element={<CourseDetailsPage />} />
        </Routes>
      </MemoryRouter>
    );

    //Assert: Check if the courseId is rendered correctly
    const courseIdElement = screen.getByText(/Details for course 123/i);
    expect(courseIdElement).toBeInTheDocument();
  });
});
