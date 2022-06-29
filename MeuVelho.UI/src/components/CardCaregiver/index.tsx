import React from 'react';
import './style.css';
import whatsappIcon from '../../assets/images/whatsapp.svg';
import api from '../../services/api';

export interface Caregiver{
  id: number;
  name: string;
  photo: string;
  biography: string;
  whatsapp: string;
  cities: any[];
  contacts: number
}

interface CardCaregiverProps{
  caregiver: Caregiver;
}

const CardCaregiver: React.FC<CardCaregiverProps> =({caregiver}) =>{
    function RegistrarNovoContato(){
      api.post('contato', {
        idCuidador: caregiver.id,
        textoAleatorio: 'okaskosoa'
      });
    }

    function getCities(cities: any[]){
      debugger;
      let citiesText = '';
      if(cities && cities.length > 0)
        cities.map((x, i) => {citiesText += i+1 === cities.length ? x[1] : `${x[1]} | `} );
      return citiesText;
    }

    return(
        <article className="cuidador-item">
        <header>
          <img src={caregiver.photo} alt={caregiver.name} />
          <div>
            <strong>{caregiver.name.toUpperCase()}</strong>
            <span>{getCities(caregiver.cities)}</span>
          </div>
        </header>
    
        <p>{caregiver.biography}</p>
    
        <footer>
          <p>
            Conexões Realizadas: 
              <strong>{caregiver.contacts}</strong>
          </p>
          <a
            onClick={RegistrarNovoContato}
            target="_blank"
            href={`https://wa.me/+55${caregiver.whatsapp}`}
          >
            <img src={whatsappIcon} alt="whatsapp" />
            Entrar em contato
          </a>
        </footer>
      </article>
    );
}

export default CardCaregiver;