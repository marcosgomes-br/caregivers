import React from 'react';
import './style.css';
import whatsappIcon from '../../assets/images/whatsapp.svg';
import api from '../../services/api';
import { i18n } from '../../translate/i18n';

export interface ICaregiver{
  id: number;
  name: string;
  photo: string;
  biography: string;
  whatsapp: string;
  cities: any[]; 
  contacts: number
}

interface ICardCaregiverProps{
  caregiver: ICaregiver;
}

const CardCaregiver: React.FC<ICardCaregiverProps> =({caregiver}) =>{
  const registerNewContact = () => {
    api.post('api/connection', { 
      idCaregiver: caregiver.id
    });
  }

  const getCities = (cities: any[]) => {
    let citiesText = '';
    if(cities && cities.length > 0)
      cities.map((x, i) => {citiesText += i+1 === cities.length ? x[1] : `${x[1]} | `} );
    return citiesText;
  }

  return(
    <article className="caregiver-card">
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
          {i18n.t('page.caregivers.card.connections').toString()}: 
          <strong>{caregiver.contacts}</strong>
        </p>
        <a
          onClick={registerNewContact}
          target="_blank"
          href={`https://wa.me/+55${caregiver.whatsapp}`} rel="noreferrer"
        >
          <img src={whatsappIcon} alt="whatsapp" />
          {i18n.t('page.caregivers.card.buttonContactUs').toString()}
        </a>
      </footer>
    </article>
  );
}

export default CardCaregiver;