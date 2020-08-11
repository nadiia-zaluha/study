import { StateController } from "Utils/StateController"
import { WorkoutState } from "service/WorkoutState"
import { WorkoutSessionManager } from "service/WorkoutSessionManager"

const state = new StateController<WorkoutSessionState>("NDIA_CUSTOMERS");

class WorkoutSessionState {
    currentWorkoutState: WorkoutState;
    status: string;
}

const defaultState: WorkoutSessionState = {
    currentWorkoutState: null,
    status: null
}

class Service {

    private static successLabel: string = "Session is completed.";
    private static manager: WorkoutSessionManager;

    public static startWorkoutSession() {
        return (dispatch) => {
            dispatch(state.setState({ currentWorkoutState: null }))
            this.manager = new WorkoutSessionManager(
                (wState) => { dispatch(state.setState({ currentWorkoutState: wState })) },
                () => {
                    console.info(this.successLabel)
                    dispatch(state.setState({ status: this.successLabel, currentWorkoutState: null }));
                }
            )
        }
    }

    public static endWorkoutSession() {
        return () => {
            if (this.manager != null) {
                this.manager.close();
            }
            else {
                throw Error("Session manager is null.");
            }
        }
    }

}

const reducer = state.getReducer();

export {
    reducer as Reducer,
    defaultState as DefaultState,
    WorkoutSessionState as State,
    Service as Service
};