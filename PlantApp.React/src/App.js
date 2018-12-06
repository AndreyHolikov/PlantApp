// App.js

import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';

import Create from './components/create.component';
import Edit from './components/edit.component';
import Index from './components/index.component';

import WorkcenterIndexComponent from './components/workcenter/index.component';
import WorkcenterEditComponent from './components/workcenter/edit.component';
import WorkcenterCreateComponent from './components/workcenter/create.component';

import 'font-awesome/css/font-awesome.min.css';
import 'bootstrap-css-only/css/bootstrap.min.css';
import 'mdbreact/dist/css/mdb.css';

import 'antd/dist/antd.css';
import './global.js';
import OptionsGeneralComponent from './components/options/general.component'

class App extends Component {
    render() {
        return (
            <Router>
                <div className="container">
                    <nav className="navbar navbar-expand-lg navbar-light bg-light">
                        <Link to={'/'} className="navbar-brand">React CRUD Example</Link>
                        <div className="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul className="navbar-nav mr-auto">
                                <li className="nav-item">
                                    <Link to={'/'} className="nav-link">Home</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to={'/create'} className="nav-link">Create</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to={'/index'} className="nav-link">Index</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to={'/workcenter/index'} className="nav-link">Workcenter</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to={'/options/general'} className="nav-link">Options</Link>
                                </li>
                            </ul>
                        </div>
                    </nav> <br />
                    <h2>Welcome to New Plant</h2> <br />
                    <Switch>
                        <Route exact path='/create' component={Create} />
                        <Route path='/edit/:id' component={Edit} />
                        <Route path='/index' component={Index} />

                        <Route path='/workcenter/index' component={WorkcenterIndexComponent} />
                        <Route path='/workcenter/edit/:id' component={WorkcenterEditComponent} />
                        <Route exact path='/workcenter/create' component={WorkcenterCreateComponent} />

                        <Route exact path='/options/general' component={OptionsGeneralComponent} />
                    </Switch>
                </div>
            </Router>
        );
    }
}

export default App;