import React from 'react';
import { Link } from 'react-router-dom';
import './style.css';
import logo from '../../assets/images/logo.svg';
import { Button } from '@mui/material';

interface PageHeaderProps{
    titulo: string;
}

const PageHeader: React.FunctionComponent<PageHeaderProps> = (props) => {
    return (
        <header className="page-header">
            <div className="top-bar-container">
                <Link to="/" >VOLTAR</Link>
                <Button variant="contained" color="inherit" size="large">Fazer Login</Button>
                <img src={logo} alt="Logo - Plataforma Meu Velho"/>
            </div>
            <div className="header-content">
                <strong>{props.titulo}</strong>
                {props.children}
            </div>
        </header>
    )
}

export default PageHeader;