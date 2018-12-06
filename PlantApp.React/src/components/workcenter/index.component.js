// index.component.js

import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Table } from 'antd';
import { GetWorkcenterIndexExpectedData } from './expected-data/workcenter.js';

export default class WorkcenterIndexComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            workcenters: []
        };
    }

    componentWillMount() {
        this.getData();
    }

    getData() {
        console.log("--global.USE_EXPECTED_DATA", global.USE_EXPECTED_DATA);

        if (global.USE_EXPECTED_DATA) {
            this.getExpectedData();
        } else {
            this.axiosGet();
        }
    }

    getExpectedData() {
        const expectedData = GetWorkcenterIndexExpectedData()
        console.log('--GetWorkcenterIndexExpectedData()', expectedData);
        this.setState({
            workcenters: expectedData
        });
    }

    axiosGet() {
        const urlWorkcenterIndex = 'http://localhost:5471/Workcenter/Index';
        //const urlWorkcenterIndex = 'https://jsonplaceholder.typicode.com/users';
        console.log('--urlWorkcenterIndex', urlWorkcenterIndex);
        //fetch('https://jsonplaceholder.typicode.com/users')
        axios.get(urlWorkcenterIndex, {
            baseURL: global.BASE_URL,
            url: '/Workcenter/Index',
            method: 'get',
            headers: { //'X-Requested-With': 'XMLHttpRequest',
                'Content-Type': 'application/json; charset=utf-8'
            },
            //timeout: 3000,
            //withCredentials: true,
            //auth: {
            //    username: 'janedoe',
            //    password: 's00pers3cret'
            //},
            responseType: 'json', // default
        })
            .then(response => {
                this.setState({ workcenters: response.data });
            })
            //.then(function (response) {
            //    this.setState({ workcenters: response.data });
            //})
            .catch(function (error) {
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log('--error.response.data', error.response.data);
                    console.log('--error.response.status', error.response.status);
                    console.log('--error.response.headers', error.response.headers);
                } else if (error.request) {
                    console.log('--error.request', error.request);
                } else {
                    console.log('--error.message', error.message);
                }
                console.log('--error.config', error.config);
                console.log('--error', error);
            });

        if (typeof this.state.workcenters !== 'undefined') {
            console.log("--this.state.workcenters", this.state.workcenters);
        } else {
            console.log('--this.state.workcenters', 'undefined');
        }
    }

    render() {
        const columns = [{
            title: 'Name',
            dataIndex: 'Name',
            key: 'Name',
        }, {
            title: 'Action',
            width: 300,
            render: (record) =>
                <div>
                    <Link to={"/workcenter/edit/" + record.Id} className="btn btn-primary">Edit</Link>
                    <Link to={"/workcenter/delete/" + record.Id} className="btn btn-danger">Delete</Link>
                </div>
        }];

        return (
            <div>
                <h2 align="center">Workcenter List</h2>
                
                <Table dataSource={this.state.workcenters} columns={columns}
                    pagination={{ pageSize: 50 }} scroll={{ y: 380 }} rowKey={record => record.Id}
                    />
                <br />
            </div>
        );
    }
}