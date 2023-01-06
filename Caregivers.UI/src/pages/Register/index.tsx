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

const Register = () => {
  const [user, setUser] = useState<IUser>({} as IUser);
  const handleNewUser = (e: FormEvent) => {
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
    <div id="page-register" className="new-caregiver">
      <PageHeader title={i18n.t('page.caregiver.title').toString()} />
      <main style={{marginTop: '-100px'}}>
        <form onSubmit={handleNewUser} onKeyDown={(e) => {
          if (e.keyCode === 13) {             
            e.preventDefault();
            return false;
          }
        }}>
          <fieldset>
            <legend>
              {i18n.t('page.caregiver.newAccount').toString()}
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
                {i18n.t('page.caregiver.button.login').toString()}
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
                      {i18n.t('page.caregiver.form.validation.passwordNotSame').toString()}
                    </p>
            }
            <button id="btn-save">{i18n.t('page.caregiver.button.registerMe').toString()}</button>
          </footer>
        </form>
      </main>
    </div>
  )
}

export default Register;