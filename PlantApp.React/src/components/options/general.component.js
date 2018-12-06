// import {OptionsGeneralComponent} from './components/options/general.component.js'

import React, { Component } from 'react';
import '../../global.js';

export default class OptionsGeneralComponent extends Component {
    constructor() {
        super();
        this.state = { cbxUseExpectedDataChecked: global.USE_EXPECTED_DATA };
    }

    cbxUseTestDataChange(event) {
        this.setState({ cbxUseExpectedDataChecked: !this.state.cbxUseExpectedDataChecked });
        global.USE_EXPECTED_DATA = event.target.checked;
    }

    render() {
        return <div className="form-check">
            <input
                type="checkbox"
                checked={this.state.cbxUseExpectedDataChecked}
                onChange={this.cbxUseTestDataChange.bind(this)}
                className="form-check-input form-control-lg"
                id="cbxUseExpectedData"
                name="cbxUseExpectedData"
            />
            <label
                className="form-check-label form-control-lg"
                htmlFor="cbxUseExpectedData">
                Use expected data: {this.state.cbxUseExpectedDataChecked ? 'Enable' : 'Disable'}
            </label>
        </div>;
    }
}