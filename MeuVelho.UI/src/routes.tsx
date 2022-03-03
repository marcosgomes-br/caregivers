import React from 'react';

import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cuidadores from './pages/Cuidadores';
import NovoCuidador from './pages/NovoCuidador';

function Routes(){
    return(
        <BrowserRouter>
            <Route path="/" exact component={Home} />
            <Route path="/cuidadores" component={Cuidadores} />
            <Route path="/novo-cuidador" component={NovoCuidador} />
        </BrowserRouter>
    )
}

export default Routes;