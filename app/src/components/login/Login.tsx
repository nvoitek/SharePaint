import { useState } from 'react';
import { Navigate } from 'react-router';
import { authorize } from '../../services/UserService';
import './Login.scss';

interface LoginProps {
    user: string,
    setUser: (user: string) => void;
    setToken: (token: string) => void;
}

export function Login(props: LoginProps) {

    const [error, setError] = useState<string>("");
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const onSubmit = (e: React.SyntheticEvent) => {
        e.preventDefault();

        authorize({ username: username, password: password })
            .then(res => {
                props.setUser(username);
                props.setToken(res.token);
                localStorage.setItem('user', JSON.stringify(res));
            })
            .catch(err => {
                setError(err.response.data);
            });
    }

    const onUsernameChange = (e: React.FormEvent<HTMLInputElement>): void => {
        setUsername(e.currentTarget.value);
    };

    const onPasswordChange = (e: React.FormEvent<HTMLInputElement>): void => {
        setPassword(e.currentTarget.value);
    };

    return (
        <div className='login'>
            {(props.user)
                ? <Navigate to={'/'} />
                : <form onSubmit={onSubmit}>
                    <input className="login-username" type="text" placeholder='username' value={username} onChange={onUsernameChange} />
                    <input className="login-password" type="password" placeholder='password' value={password} onChange={onPasswordChange} />
                    <input className="login-submit" type="submit" value="Submit" />
                    {(error) ? <p>{error}</p> : ''}
                </form>
            }
        </div>
    );
}