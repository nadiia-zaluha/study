import * as React from "react"

export class StateProps {
    canStart: boolean;
    canEnd: boolean;
}

export class DispatchProps {
    start: () => void;
    end: () => void;
}

export class workoutControlPanel extends React.Component<StateProps & DispatchProps, {}> {

    render() {
        return <div>
            {this.props.canStart && <button onClick={this.props.start}>Start</button>}
            {this.props.canEnd && <button onClick={this.props.end}>End</button>}
        </div>
    }
}
