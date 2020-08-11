import { WorkoutSessionSimulator } from "./WorkoutSessionSimulator"
import { WorkoutState } from "./WorkoutState"

export class WorkoutSessionManager {

    private simulator: WorkoutSessionSimulator;

    constructor(
        listener: (state: WorkoutState) => void,
        onWorkoutEnd: () => void,
    ) {
        this.simulator = new WorkoutSessionSimulator(
            listener,
            onWorkoutEnd,
            30
        );
    }

    public close() {
        if (this.simulator != null) {
            this.simulator.close();
        }
        else {
            throw Error("Session is disposed.");
        }
    }

}