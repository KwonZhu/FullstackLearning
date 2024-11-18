import { renderHook, waitFor } from '@testing-library/react';
import { useCourses } from './useCourses';
import { Course } from '../types/Course';

describe('useCourses Hook', () => {
  // Define mock courses data
  const mockCourses: Course[] = [
    {
      id: 1,
      title: 'React Basics',
      description: 'Learn React from scratch',
      lessons: 10,
    },
    {
      id: 2,
      title: 'Advanced TypeScript',
      description: 'Deep dive into TypeScript features',
      lessons: 15,
    },
  ];

  beforeEach(() => {
    // Clear all previous fetch mocks before each test
    jest.clearAllMocks();
  });

  it('fetches courses data successfully', async () => {
    // Mock fetch to return a successful response
    globalThis.fetch = jest.fn().mockResolvedValueOnce({
      ok: true,
      json: async () => mockCourses, // Return the mockCourses data when the fetch resolves
    });

    // Render the useCourses hook to test its behavior
    const { result } = renderHook(() => useCourses());

    // Initial state checks before date is fetched
    expect(result.current.loading).toBe(true);
    expect(result.current.courses).toEqual([]);
    expect(result.current.error).toBe(null);

    // Wait for loading to become false, which indicates that fetching is complete
    await waitFor(() => expect(result.current.loading).toBe(false));

    // Now you can safely check the courses data, error, and fetch call
    // Checks if the courses data was fetched and set correctly
    expect(result.current.courses).toEqual(mockCourses);
    expect(result.current.error).toBe(null);
    expect(globalThis.fetch).toHaveBeenCalledWith(
      'https://my-json-server.typicode.com/JustinHu8/courseCardMock/courseCards'
    );
  });

  it('handles non-OK fetch response', async () => {
    // Mock fetch to simulate a non-OK response (e.g., 404, 500)
    globalThis.fetch = jest.fn().mockResolvedValueOnce({
      ok: false,
    });

    // Render the useCourses hook to test its behavior
    const { result } = renderHook(() => useCourses());

    // Wait for loading to become false, which indicates that fetching is complete
    await waitFor(() => expect(result.current.loading).toBe(false));

    // Now you can safely check the courses data, error, and fetch call
    // Check if error message is set when the response is not OK
    expect(result.current.courses).toEqual([]);
    expect(result.current.error).toBe('Failed to fetch courses');
    expect(globalThis.fetch).toHaveBeenCalledWith(
      'https://my-json-server.typicode.com/JustinHu8/courseCardMock/courseCards'
    );
  });

  it('handles fetch error correctly', async () => {
    // Mock fetch to simulate a failed fetch request
    globalThis.fetch = jest.fn().mockRejectedValueOnce(new Error('Fetch error'));

    const { result } = renderHook(() => useCourses());

    expect(result.current.loading).toBe(true);
    expect(result.current.courses).toEqual([]);
    expect(result.current.error).toBe(null);

    await waitFor(() => expect(result.current.loading).toBe(false));

    // Check if the error state is set correctly
    expect(result.current.courses).toEqual([]);
    expect(result.current.error).toBe('Fetch error');
    expect(globalThis.fetch).toHaveBeenCalledWith(
      'https://my-json-server.typicode.com/JustinHu8/courseCardMock/courseCards'
    );
  });
});
