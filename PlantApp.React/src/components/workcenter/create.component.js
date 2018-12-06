// create.component.js

import React, { Component } from 'react';
import axios from 'axios';

export default class WorkcenterCreateComponent extends Component {
    constructor(props) {
        super(props);
        this.onChangeName = this.onChangeName.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            name: '',
        }
    }
    onChangeName(e) {
        this.setState({
            name: e.target.value
        });
    }

    onSubmit(e) {
        e.preventDefault();
        const obj = {
            name: this.state.name,
        };
        axios.post('./workcenter/add', obj)
            .then(res => console.log(res.data));

        this.props.history.push('/workcenter/index');
    }

    render() {
        return (
            <div style={{ marginTop: 10 }}>
                <h3>Add New Workcenter</h3>
                <form onSubmit={this.onSubmit}>
                    <div className="form-group">
                        <label>Name:  </label>
                        <input
                            type="text"
                            className="form-control"
                            value={this.state.name}
                            onChange={this.onChangeName}
                        />
                    </div>
                    
                    <div className="form-group">
                        <input type="submit" value="Register Workcenter" className="btn btn-primary" />
                    </div>
                </form>
            </div>
        )
    }
}