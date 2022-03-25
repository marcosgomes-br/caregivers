import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { i18n } from '../../translate/i18n';
import './style.css';
import logoImage from '../../assets/images/logo.svg';
import heart from '../../assets/images/coracao.svg';
import ptBr from '../../assets/images/pt-br.svg';
import enUs from '../../assets/images/en-us.svg'
import api from '../../services/api';
import { Container, Grid } from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch, faHeartPulse } from '@fortawesome/free-solid-svg-icons';

function Home() {
  const [totalConexoes, setTotalConexoes] = useState(0);
  useEffect(() =>{
    api.get('contato').then(response => {
      setTotalConexoes(response.data)
    });
  }, []);

  const alterLanguage = (currentLanguage: string): void => {
    window.localStorage.setItem('i18nextLng', currentLanguage);
    window.location = window.location;
  }

  return (
    <div id="home-page">
      <div className="languages" style={{display: 'inline', float: 'right', margin: '1rem'}}>
        <img onClick={() => {alterLanguage('pt-BR')}} src={ptBr} alt="pt-BR" style={{ width: '4.3rem' }}></img>
        <img onClick={() => {alterLanguage('en-US')}} src={enUs} alt="en-US" style={{ width: '4rem' }}></img>
      </div>
      <Container maxWidth="md">
        <Grid container spacing={2} alignItems="center" direction="row" className="container">
          <Grid item xs={7} style={{paddingRight: '1rem'}} className="logo-container">
            <img src={logoImage} alt="Logo da Plataforma Meu Velho"/>
            <h2>{i18n.t('page.home.slogan')}</h2>
          </Grid>
          <Grid item xs={5} className="total-connections-container">
            <img src={heart} alt="Coração" />
            <span className="total-connections">
              {totalConexoes} {i18n.t('page.home.connections')}
            </span>
          </Grid>
        </Grid>
        <Grid container spacing={2} className="container">
          <Grid item xs={12} className="buttons-container">
            <Link to="/novo-cuidador">
            <FontAwesomeIcon icon={faHeartPulse} style={{paddingRight: '1rem', fontSize: '3.5rem'}} />  
              {i18n.t('page.home.btnGuardiao')}
              </Link>
            <Link to="/cuidadores">
              <FontAwesomeIcon icon={faSearch} style={{paddingRight: '1rem', fontSize: '3rem'}} /> 
              {i18n.t('page.home.btnFind')}
            </Link>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}

export default Home;
