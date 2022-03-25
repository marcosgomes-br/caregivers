import React, { useState, FormEvent, useEffect } from 'react';
import PageHeader from '../../components/PageHeader';
import Select from '../../components/Select';
import warningIcon from '../../assets/images/warning.svg';
import Input from '../../components/Input';
import Textarea from '../../components/Textarea';
import Multiselect from 'multiselect-react-dropdown';
import api from '../../services/api';
import './style.css';

const sexoMasculino = { label: 'FEMININO', value: '0' }, 
      sexoFeminino = { label: 'MASCULINO', value: '1' }, 
      sexoOutro = { label: 'PREFIRO NÃO INFORMAR', value: '2' };

interface Iopcoes {
  nome: string,
  id: number,
}

function NovoCuidador(){
    const [cidades, setCidades] = useState<Iopcoes[]>([]);
    const [nome, setNome] = useState('');
    const [sexo, setSexo] = useState('');
    const [foto, setFoto] = useState('');
    const [biografia, setBiografia] = useState('');
    const [whatsapp, setWhatsapp] = useState('');  
    const [cidadesAtendidas, setCidadesAtendidas] = useState<Iopcoes[]>([]);

    useEffect(() => {
      api.get('cidade').then(response => {setCidades(response.data)});
    }, []);

    function handleNovoCuidador(e: FormEvent){
      e.preventDefault();
      
      api.post('cuidador', {
        nome,
        sexo: parseInt(sexo),
        foto,
        biografia,
        whatsapp,
        cidadesAtendidas: cidadesAtendidas.map(x => x.id)
      })
      .then(() => {
        alert("cadastro realizado com sucesso!");
      })
      .catch(() => {
        alert("Erro ao cadastrar cuidador");
      });
    }

    return (
        <div id="page-cuidadores-list" className="novoCuidador">
          <PageHeader titulo="Que incrível que você quer cuidar de alguém!" />
            <main style={{marginTop: '-100px'}}>
              <form onSubmit={handleNovoCuidador} onKeyDown={(e) => {
                if (e.keyCode == 13) {             
                  e.preventDefault();
                  return false;
                }
              }}>
                <fieldset>
                  <legend>Seus dados</legend>
        
                    <Input
                      name="nome"
                      label="Nome completo"
                      value={nome}
                      onChange={(e) => { setNome(e.target.value); }}
                    />
                    <Select
                      name="sexo"
                      label="Sexo"
                      value={sexo}
                      options={[sexoMasculino, sexoFeminino, sexoOutro]}
                      onChange={(e) => { setSexo(e.target.value); }}
                    />
                    <Input
                      name="foto"
                      label="Link do Avatar"
                      value={foto}
                      onChange={(e) => { setFoto(e.target.value); }}
                    />
                    <Input
                      name="whatsapp"
                      label="Whatsapp"
                      value={whatsapp}
                      onChange={(e) => { setWhatsapp(e.target.value); }}
                    />
                    <Textarea
                      name="biografia"
                      label="Biografia"
                      value={biografia}
                      onChange={(e) => { setBiografia(e.target.value); }}
                    />
                </fieldset>
                <fieldset>
                    <legend style={{'marginBottom': '0'}}>Cidades Atendidas</legend>
                    <Multiselect
                        name="cidadesAtendidas"
                        options={cidades}
                        onSelect={(selecionados) => { setCidadesAtendidas(selecionados as Iopcoes[]) }}
                        onRemove={(selecionados) => { setCidadesAtendidas(selecionados as Iopcoes[]) }}
                        displayValue="nome"
                        placeholder=''                        
                        className='input' 
                        emptyRecordMsg={ cidades.length == 0 ? 'Carregando...' : 'Não há registros'}                       
                      />    
                </fieldset>
                <footer>
                    <p>
                        <img src={warningIcon} alt="Aviso Importante" />
                        Importante! <br />
                        Preencha todos os dados
                    </p>
                    <button id="btn-salvar" >Salvar Cadastro</button>
                </footer>
            </form>
        </main>
     </div>
    )
}

export default NovoCuidador;