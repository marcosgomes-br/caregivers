import React, { useState, FormEvent } from 'react';
import PageHeader from '../../components/PageHeader';
import { i18n } from '../../translate/i18n';
import Input from '../../components/Input';
import api from '../../services/api';
import './style.css';
import { Button } from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSignIn } from '@fortawesome/free-solid-svg-icons';

interface IUser{
  email: string,
  password: string,
  confirmPassword: string,
  phoneNumber: string
}

const NovoCuidador = () => {
  const [user, setUser] = useState<IUser>({} as IUser);
    const handleNovoCuidador = (e: FormEvent) => {
      e.preventDefault();
      
      api.post('auth/create', user)
      .then(() => {
        alert("cadastro realizado com sucesso!");
      })
      .catch(() => {
        alert("Erro ao cadastrar cuidador");
      });
    }

    return (
        <div id="page-cuidadores-list" className="novoCuidador">
          <PageHeader titulo={i18n.t('page.caregiver.title')} />
            <main style={{marginTop: '-100px'}}>
              <form onSubmit={handleNovoCuidador} onKeyDown={(e) => {
                if (e.keyCode === 13) {             
                  e.preventDefault();
                  return false;
                }
              }}>
                <fieldset>
                  <legend>
                    {i18n.t('page.caregiver.newAccount')}
                    <Button 
                      variant="contained" 
                      color="inherit" 
                      size="large" 
                      style={{
                        background: 'none', 
                        color: '#00A990', 
                        border: '2px solid #00A990'
                      }}
                    >
                      <FontAwesomeIcon icon={faSignIn} style={{paddingRight: '.5rem'}} /> 
                      {i18n.t('page.caregiver.button.login')}
                    </Button>  
                  </legend>      
                  <Input                     
                    name="email"
                    type="email"
                    value={user.email}
                    required
                    onChange={(e) => { setUser({...user, email: e.target.value }) }}
                    placeholder={i18n.t('page.caregiver.form.email')}
                  />
                  <Input                     
                    name="phone"
                    type="tel"
                    value={user.phoneNumber}
                    required
                    onChange={(e) => { setUser({...user, phoneNumber: e.target.value }) }}
                    placeholder={i18n.t('page.caregiver.form.phoneNumber')}
                  />
                  <Input                     
                    name="password"
                    type="password"
                    value={user.password}
                    required
                    onChange={(e) => { setUser({...user, password: e.target.value }) }}
                    placeholder={i18n.t('page.caregiver.form.password')}
                  />
                  <Input                     
                    name="confirm-password"
                    type="password"
                    value={user.confirmPassword}
                    required
                    onChange={(e) => { setUser({...user, confirmPassword: e.target.value }) }}
                    placeholder={i18n.t('page.caregiver.form.confirmPassword')}
                  />
                </fieldset>
                <footer>
                  { (user.password !== user.confirmPassword && user.confirmPassword) &&
                    <p>
                      As senhas não são iguais. Tente novamente.
                    </p>
                  }
                    <button id="btn-salvar">{i18n.t('page.caregiver.button.registerMe')}</button>
                </footer>
            </form>
        </main>
     </div>
    )
}

export default NovoCuidador;

/*
                    <Input
                      name="nome"
                      value={nome}
                      onChange={(e) => { setNome(e.target.value); }}
                      placeholder="Nome Completo"
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
                        emptyRecordMsg={ cidades.length === 0 ? 'Carregando...' : 'Não há registros'}                       
                      />    
*/