import { NavLink } from 'react-router-dom';
import './Header.scss';

interface HeaderProps {
    user: string,
    resetUser: () => void;
}

export function Header(props: HeaderProps) {

    return (
        <div className='header'>
            <p>Logged in as {props.user}</p>
            <NavLink to='/login' onClick={props.resetUser}>Logout</NavLink>
        </div>
    );

}