import * as React from "react"
import { WorkoutState } from "service/WorkoutState"

export class StateProps {
    workoutState: WorkoutState;
}

export class workoutSessionState extends React.Component<StateProps, {}> {

    render() {
        if (this.props.workoutState == null) return null;
        return <div>
            {this.props.workoutState.duration_countdown}
        </div>
    }
}
