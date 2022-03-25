import React, { useState, useEffect } from 'react';
import PageHeader from '../../components/PageHeader';
import './style.css';
import CuidadorItem, { Cuidador } from '../../components/CuidadorItem';
import api from '../../services/api';

function Cuidadores(){  
    const [cuidadores, setCuidadores] = useState([]);
    
    useEffect(() => {
        api.get('cuidador').then(response => {setCuidadores(response.data)});
    }, []);

    return (
        <div id="page-novo-cuidador">
            <PageHeader titulo="Estes são os cuidadores disponíveis:" />
            <main style={{marginTop: '-100px'}}>
                {cuidadores.map((cuidador: Cuidador) => {
                    return <CuidadorItem key={cuidador.id} cuidador={cuidador}/>
                })}
            </main>
        </div>
    )
}

export default Cuidadores;