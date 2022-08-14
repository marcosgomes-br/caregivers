import React from 'react';
import { Link } from 'react-router-dom';
import './style.css';
import logo from '../../assets/images/logo.svg';
import { i18n } from '../../translate/i18n';

interface IPageHeaderProps{
  title: string;
    children?: React.ReactNode;
}

const PageHeader: React.FC<IPageHeaderProps> = ({title, children}) => {
  return (
    <header className="page-header">
      <div className="top-bar-container">
        <Link to="/">{i18n.t('component.pageHeader.button.backPage').toString()}</Link>
        <img src={logo} alt="Logo - Meu Velho" />
      </div>
      <div className="header-content">
        <strong>{title}</strong>
        {children}
      </div>
    </header>
  );
}

export default PageHeader;
