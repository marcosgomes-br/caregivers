import React, { useState, useEffect } from 'react';
import PageHeader from '../../components/PageHeader';
import './style.css';
import CardCaregiver, { ICaregiver } from '../../components/CardCaregiver';
import api from '../../services/api';

function Caregivers(){  
    const [caregivers, setCaregivers] = useState([]);
    
    useEffect(() => {
        api.get('caregiver').then(response => {setCaregivers(response.data)});
    }, []);

    return (
        <div id="page-novo-cuidador">
            <PageHeader titulo="Estes são os cuidadores disponíveis:" />
            <main style={{marginTop: '-100px'}}>
                {caregivers.map((caregiver: ICaregiver) => {
                    return <CardCaregiver key={caregiver.id} caregiver={caregiver}/>
                })}
            </main>
        </div>
    )
}

export default Caregivers;