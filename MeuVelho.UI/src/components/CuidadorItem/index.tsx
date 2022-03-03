import React from 'react';
import './style.css';
import whatsappIcon from '../../assets/images/whatsapp.svg';
import api from '../../services/api';

export interface Cuidador{
  id: number;
  nome: string;
  foto: string;
  biografia: string;
  whatsapp: string;
  cidades: string[];
  contatos: number
}

interface CuidadorItemProps{
  cuidador: Cuidador;
}

const CuidadorItem: React.FC<CuidadorItemProps> =({cuidador}) =>{
    function RegistrarNovoContato(){
      console.log(cuidador.id)
      api.post('contato', {
        idCuidador: cuidador.id,
        textoAleatorio: 'okaskosoa'
      });
    }

    function listarCidades(cidades: string[]){
      let cidadesStr = '';
      cidades.map((x, i) => {cidadesStr += i+1 === cidades.length ? x : `${x} | `} );
      return cidadesStr;
    }

    return(
        <article className="cuidador-item">
        <header>
          <img src={cuidador.foto} alt={cuidador.nome} />
          <div>
            <strong>{cuidador.nome.toUpperCase()}</strong>
            <span>{listarCidades(cuidador.cidades)}</span>
          </div>
        </header>
    
        <p>{cuidador.biografia}</p>
    
        <footer>
          <p>
            Conexões Realizadas: 
              <strong>{cuidador.contatos}</strong>
          </p>
          <a
            onClick={RegistrarNovoContato}
            target="_blank"
            href={`https://wa.me/+55${cuidador.whatsapp}`}
          >
            <img src={whatsappIcon} alt="whatsapp" />
            Entrar em contato
          </a>
        </footer>
      </article>
    );
}

export default CuidadorItem;