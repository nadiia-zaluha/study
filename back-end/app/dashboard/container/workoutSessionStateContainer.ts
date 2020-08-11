import * as reactRedux from 'react-redux';
import { AppStore } from "state/store";
import * as workout from "state/workout"

import { workoutSessionState, StateProps } from "../workoutSessionState"

const mapStateToProps = (state: AppStore, ownProps): StateProps => {
    return {
        workoutState: state.workout.currentWorkoutState
    }
}

export default reactRedux.connect(mapStateToProps, null)(workoutSessionState); 