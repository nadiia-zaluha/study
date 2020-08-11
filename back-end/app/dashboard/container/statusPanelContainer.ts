import * as reactRedux from 'react-redux';
import { AppStore } from "state/store";
import * as workout from "state/workout"

import { StatusPanel, StateProps } from "../statusPanel"

const mapStateToProps = (state: AppStore, ownProps): StateProps => {

    return {
        status: state.workout.status
    }
}


export default reactRedux.connect(mapStateToProps, null)(StatusPanel); 