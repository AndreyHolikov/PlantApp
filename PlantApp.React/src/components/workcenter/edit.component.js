// edit.component.js

import React, { Component } from 'react';
import axios from 'axios';
import { GetWorkcenterEditExpectedData } from './expected-data/workcenter.js';

export default class WorkcenterEditComponent extends Component {
    constructor(props) {
        super(props);
        this.onChangeName = this.onChangeName.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            Id: this.props.match.params.id,
            Name: ''
        }
    }

    componentWillMount() {
        this.getData();
    }

    getData() {
        this.axiosGet();

        console.log("--global.USE_EXPECTED_DATA", global.USE_EXPECTED_DATA);
        if (global.USE_EXPECTED_DATA) {
            this.getExpectedData();
        } 
    }

    getExpectedData() {
        const Id = this.state.Id;
        console.log('--id', Id);
        const expectedData = GetWorkcenterEditExpectedData(Id);
        console.log('--expectedData', expectedData);
        if (typeof expectedData !== 'undefined') {
            this.setState({
                Name: expectedData.Name
            });
        } else {
            this.setState({
                Id: '',
                Name: ''
            });
        }
    }

    axiosGet() {
        const urlWorkcenterEdit = '' + this.props.match.params.id;

        axios.get(urlWorkcenterEdit, '', {
            baseURL: global.BASE_URL,
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Request-Method': '*',
                'Content-Type': 'application/json; charset=utf-8'
            }
        })
            .then(response => {
                this.setState({
                    Name: response.data.Name,
                });
            })
            .catch(function (error) {
                console.log('--error.statys', error.statys);
                console.log('--error', error);
            })
    }

    onChangeName(e) {
        this.setState({
            Name: e.target.value
        });
    }

    onSubmit(e) {
        e.preventDefault();

        const obj = {
            Id: this.state.Id,
            Name: this.state.Name
        };

        const urlWorkcenterEdit = 'workcenter/edit/';
        //'/workcenter/edit/'
        axios.post(urlWorkcenterEdit, obj, {
            baseURL: global.BASE_URL
        })
            .then(res => console.log(res.data))
            .catch(function (error) {
                console.log(error);
            });

        this.props.history.push('/workcenter/index');
    }

    render() {
        return (
            <div style={{ marginTop: 10 }}>
                <h3 align="center">Edit Workcenter</h3>
                <form onSubmit={this.onSubmit}>
                    <input
                        id="Id"
                        name="Id"
                        type="hidden"
                        value={this.state.Id}
                    />
                    <div className="form-group">
                        <label>Name:  </label>
                        <input
                            id="Name"
                            name="Name"
                            type="text"
                            className="form-control"
                            value={this.state.Name}
                            onChange={this.onChangeName}
                        />
                    </div>

                    <div className="form-group">
                        <input type="submit"
                            value="Update Workcenter"
                            className="btn btn-primary" />
                    </div>
                </form>
            </div>
        )
    }
}