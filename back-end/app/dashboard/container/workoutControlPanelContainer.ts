import * as reactRedux from 'react-redux';
import { AppStore } from "state/store";
import * as workout from "state/workout"

import { workoutControlPanel, StateProps, DispatchProps } from "../workoutControlPanel"

const mapStateToProps = (state: AppStore, ownProps): StateProps => {

    return {
        canStart: state.workout.currentWorkoutState == null,
        canEnd: state.workout.currentWorkoutState != null
    }
}

const mapDispatchToProps = (dispatch, ownProps): DispatchProps => {
    return {
        start: () => { dispatch(workout.Service.startWorkoutSession()) },
        end: () => { dispatch(workout.Service.endWorkoutSession()) }
    }
}

export default reactRedux.connect(mapStateToProps, mapDispatchToProps)(workoutControlPanel); 