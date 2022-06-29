import React from 'react';

import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Caregivers from './pages/Caregivers';
import Register from './pages/Register';

const Routes: React.FC = () => {
    return(
        <BrowserRouter>
            <Route path="/" exact component={Home} />
            <Route path="/caregivers" component={Caregivers} />
            <Route path="/register" component={Register} />
        </BrowserRouter>
    )
}

export default Routes;