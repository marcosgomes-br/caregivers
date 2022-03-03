import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import './style.css';
import logoImage from '../../assets/images/logo.svg';
import imageHome from '../../assets/images/home-page.svg';
import coracao from '../../assets/images/coracao.svg';
import api from '../../services/api';

function Home() {
  const [totalConexoes, setTotalConexoes] = useState(0);
  useEffect(() =>{
    api.get('contato').then(response => {
      setTotalConexoes(response.data)
    });
  }, [])

  return (
      <div id="page-landing">
          <div id="page-landing-content" className="container">
              <div className="logo-container">
                  <img src={logoImage} alt="Logo da Plataforma Meu Velho"/>
                  <h2>A plataforma dos guardiões de idosos.</h2>
              </div>
              <img src={imageHome} alt="Cuidador de Idosos" className="hero-image" />
              <div className="buttons-container">
                <Link to="/cuidadores" className="cliente">Encontrar Cuidador</Link>
                <Link to="/novo-cuidador" className="cuidador">Cuidar de Alguém</Link>
              </div>
              <span className="total-connections">
                  Total de {totalConexoes} conexões já realizadas. <img src={coracao} alt="Coração Azul" /> 
              </span>
          </div>
      </div>
  );
}

export default Home;
