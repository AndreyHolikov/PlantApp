// ./expected-data/workcenter.js

import data from './workcenters.json';

export function GetWorkcenterIndexExpectedData() {
    console.log('Get Workcenter Index Expected Data');
    return data;
}
export function GetWorkcenterEditExpectedData(id) {
    console.log('Get Workcenter Edit Expected Data');
    return data[id];
}

