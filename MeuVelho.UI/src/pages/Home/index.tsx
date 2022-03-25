import React, { useState, useEffect } from 'react';
import { i18n } from '../../translate/i18n';
import './style.css';
import logoImage from '../../assets/images/logo.svg';
import heart from '../../assets/images/coracao.svg';
import ptBr from '../../assets/images/pt-br.svg';
import enUs from '../../assets/images/en-us.svg'
import api from '../../services/api';
import { Container, Grid } from '@mui/material';
import { faSearch, faHeartPulse } from '@fortawesome/free-solid-svg-icons';
import Button from './components/button';

const alterLanguage = (currentLanguage: string): void => {
  window.localStorage.setItem('i18nextLng', currentLanguage);
  window.location = window.location;
}

function Home() {
  const [totalConnections, setTotalConnections] = useState(0);
  useEffect(() =>{
    api.get('contato').then(response => {
      setTotalConnections(response.data)
    });
  }, []);

  return (
    <div id="home-page">
      <div className="languages" style={{display: 'inline', float: 'right', margin: '1rem'}}>
        <img onClick={() => {alterLanguage('pt-BR')}} src={ptBr} alt="pt-BR" style={{ width: '4.3rem' }}></img>
        <img onClick={() => {alterLanguage('en-US')}} src={enUs} alt="en-US" style={{ width: '4rem' }}></img>
      </div>
      <Container maxWidth="md">
        <Grid container spacing={2} alignItems="center" direction="row" className="container">
          <Grid item xs={7} style={{paddingRight: '1rem'}} className="logo-container">
            <img src={logoImage} alt="Logo Meu Velho"/>
            <h2>{i18n.t('page.home.slogan')}</h2>
          </Grid>
          <Grid item xs={5} className="total-connections-container">
            <img src={heart} alt={i18n.t('page.home.altHeart')} />
            <span className="total-connections">
              {totalConnections} {i18n.t('page.home.connections')}
            </span>
          </Grid>
        </Grid>
        <Grid container spacing={2} className="container">
          <Grid item xs={12} className="buttons-container">
            <Button to="/novo-cuidador" icon={faHeartPulse} text={i18n.t('page.home.btnGuardiao')} />
            <Button to="/cuidadores" icon={faSearch} text={i18n.t('page.home.btnFind')} />
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}

export default Home;