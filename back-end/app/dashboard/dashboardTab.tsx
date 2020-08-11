import * as React from "react"
import WorkoutControlPanelContainer from "./container/workoutControlPanelContainer"
import WorkoutSessionStateContainer from "./container/workoutSessionStateContainer"
import StatusContainer from "./container/statusPanelContainer"

export class Dashboard extends React.Component<{}, {}> {

    render() {
        return <section>
            <StatusContainer />
            <WorkoutControlPanelContainer />
            <WorkoutSessionStateContainer />
        </section>
    }
}
