import * as React from "react"

export class StateProps {
    status: string;
}

export class StatusPanel extends React.Component<StateProps, {}> {

    render() {
        return <div>
            {this.props.status}
        </div>
    }
}
