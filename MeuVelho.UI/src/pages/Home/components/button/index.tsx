import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';

interface IButtonProps{
    to: string;
    icon: any;
    text: any;
}

const Button: React.FC<IButtonProps> = ({to, icon, text}) => {
    return(
        <Link to={to}>
            <FontAwesomeIcon icon={icon} style={{paddingRight: '1rem', fontSize: '3rem'}} /> 
            {text}
        </Link>
    );
}

export default Button;