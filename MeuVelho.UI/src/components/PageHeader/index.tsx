import React from 'react';
import { Link } from 'react-router-dom';
import './style.css';
import logo from '../../assets/images/logo.svg';

interface IPageHeaderProps{
    titulo: string;
    children?: React.ReactNode;
}

const PageHeader: React.FC<IPageHeaderProps> = ({titulo, children}) => {
  return (
    <header className="page-header">
      <div className="top-bar-container">
        <Link to="/">VOLTAR</Link>
        <img src={logo} alt="Logo - Plataforma Meu Velho" />
      </div>
      <div className="header-content">
        <strong>{titulo}</strong>
        {children}
      </div>
    </header>
  );
}

export default PageHeader;
