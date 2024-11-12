import { useEffect, useState } from 'react';
import { Course } from '../types/Course';

export const useCourse = () => {
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const response = await fetch('https://my-json-server.typicode.com/JustinHu8/courseCardMock/courseCards');
        if (!response.ok) {
          throw new Error('Failed to fetch courses');
        }
        const data: Course[] = await response.json();
        setCourses(data);
      } catch (error: any) {}
    };
    fetchCourses();
  }, []);

  return { courses };
};
