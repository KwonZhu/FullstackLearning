import { useState } from 'react';

interface LoginPageProps {
  onSubmit: (username: string, password: string) => void;
}

const LoginPage: React.FC<LoginPageProps> = ({ onSubmit }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    // Add validation: Prevent submission if either field is empty
    if (username.trim() === '' || password.trim() === '') {
      return;
    }

    onSubmit(username, password);
  };

  return (
    <div>
      <h2>Please log in to continue</h2>
      <form onSubmit={handleSubmit}>
        <label>
          username:
          <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
        </label>
        <label>
          Password:
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </label>
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

export default LoginPage;
