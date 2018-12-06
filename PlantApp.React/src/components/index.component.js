// index.component.js

import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import TableRow from './TableRow';
import { Table } from 'antd';

export default class Index extends Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: []
        };
    }

    axiosGet() {
        axios.get('http://localhost:5471/TechnicalSpecification/GetBusiness')
            .then(response => {
                this.setState({ tasks: response.data });
            })
            .catch(function (error) {
                console.log(error);
            })
    }

    axiosGetTest = () => {
        this.setState({
            tasks : [
                {
                    person_name: 1,
                    business_name: 'Create an example1',
                    business_gst_number: 'Create an example of how to use the component',
                },
                {
                    person_name: 2,
                    business_name: 'Improve',
                    business_gst_number: 'Improve the component!',
                },
            ] });
    }

    componentDidMount() {
        this.axiosGetTest();
        console.log("--this.state.tasks", this.state);
    }

    tabRow() {
        return this.state.tasks.map(function (object, i) {
            return <TableRow obj={object} key={i} />;
        });
    }

    



    render() {
        const columns = [{
            title: 'Workcenter',
            dataIndex: 'workcenter',
            key: 'Workcenter',
            width: 150,
        } , {
            title: 'Date',
            dataIndex: 'date',
            key: 'date',
            width: 100,
            
        }, {
            title: 'User',
            dataIndex: 'name',
            key:'name',
            width: 150
        }, {
            title: 'Age',
                dataIndex: 'age',
                key: 'age',
                width: 50,
        }, {
            title: 'Address',
                dataIndex: 'address',
                key: 'address',
                width: 150,
        }, {
            title: 'Status',
                dataIndex: 'status',
                key: 'status',
                width: 150,
            filters: [{
                text: 'Open',
                value: 'Open',
            }, {
               text: 'Close',
               value: 'Close',
            }],
            filterMultiple: false,
            onFilter: (value, record) => record.status.indexOf(value) === 0,
            sorter: (a, b) => a.status.length - b.status.length,
        }, {
                title: 'Action',
            dataIndex: '',
            key: 'ex',
                render: (record) =>
                    <div>
                        <Link to={"/workcenter/edit/" + record.id} className="btn btn-primary">Edit</Link>
                        <Link to={"/workcenter/delete/" + record.id} className="btn btn-danger">Delete</Link>
                    </div>
        }];

        const data = [];
        for (let i = 10; i < 100; i++) {
            data.push({
                key: i,
                date: `2014-12-24 10:30:00`,
                name: `Edward King ${i}`,
                age: 32,
                address: `London, Park Lane no. ${i}`,
                status: i % 2 === 0 ? 'Open' : 'Close',
                description: 'My name is John Brown, I am 32 years old, living in New York No. 1 Lake Park.',
            });
        }
        return (
            <div>
                <h2 align="center">Task List</h2>
                
                <Table dataSource={data} columns={columns}
                    expandedRowRender={record => <p style={{ margin: 0 }}>{record.description}</p>}
                    pagination={{ pageSize: 50 }} scroll={{ y: 340 }}
                     />

                <br />

                <table className="table table-striped" style={{ marginTop: 20 }}>
                    <thead>
                        <tr>
                            <th>Workcenter</th>
                            <th>Business</th>
                            <th>GST Number</th>
                            <th colSpan="2">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.tabRow()}
                    </tbody>
                </table>
                
            </div>
        );
    }
}