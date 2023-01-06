import React, { useState, useEffect } from 'react';
import PageHeader from '../../components/PageHeader';
import { i18n } from '../../translate/i18n';
import './style.css';
import CardCaregiver, { ICaregiver } from '../../components/CardCaregiver';
import api from '../../services/api';

const Caregivers: React.FC = () => {
  const [caregivers, setCaregivers] = useState([]);

  useEffect(() => {
    api.get('caregiver').then((response) => { setCaregivers(response.data); });
  }, []);

  return (
    <div id="page-caregivers">
      <PageHeader title={i18n.t('page.caregivers.title').toString()} />
      <main style={{ marginTop: '-100px' }}>
        {caregivers.map((caregiver: ICaregiver) => <CardCaregiver key={caregiver.id} caregiver={caregiver} />)}
      </main>
    </div> 
  );
};

export default Caregivers;