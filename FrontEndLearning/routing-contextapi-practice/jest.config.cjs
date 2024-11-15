module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'jest-environment-jsdom', // Required for React Testing Library to emulate a browser environment
  transform: {
    '^.+\\.(ts|tsx)$': 'ts-jest',
  },
  moduleNameMapper: {
    '\\.(css|less|scss|sass)$': 'identity-obj-proxy', // Handle CSS imports in tests
  },
  setupFilesAfterEnv: ['<rootDir>/jest.setup.ts'], // Set up the testing environment
};
