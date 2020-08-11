import { WorkoutState } from "./WorkoutState"
import ExcelptionHelper from "Utils/ExceptionHelper"

export class WorkoutSessionSimulator {

    private speedKph: number = 0.1875;
    private caloriesBurnRate: number = 0.1875;
    private workoutDuration: number;
    private heartRate: number = 127;
    private refreshTimeoutSeconds: number = 0.5;

    private listener: (state: WorkoutState) => void;
    private onWorkoutEnd: () => void;

    private history: Array<WorkoutState>;
    private _isDisposed: boolean = false;

    constructor(
        listener: (state: WorkoutState) => void,
        onWorkoutEnd: () => void,
        totalDurationMinutes: number
    ) {
        this.history = new Array<WorkoutState>();
        this.listener = ExcelptionHelper.checkNotNull(listener);
        this.onWorkoutEnd = ExcelptionHelper.checkNotNull(onWorkoutEnd);
        this.workoutDuration = ExcelptionHelper.checkNotNull(totalDurationMinutes) * 60;

        this.init();
        this.triggerSyncing();
    }

    public close() {
        if (!this._isDisposed) this._isDisposed = true;
    }

    private init = () => {
        let startStep: WorkoutState =
        {
            speed: this.speedKph,
            calories: 0,
            duration: 0,
            duration_countdown: this.workoutDuration,
            distance: 0,
            pace: 0,
            grade: 0,
            heart_rate: this.heartRate
        }

        this.registerStep(startStep);
    }

    private registerStep = (workoutState: WorkoutState) => {
        this.history.push(workoutState);
        this.listener(workoutState);
    }

    private triggerSyncing = () => {
        if (this.flushTimerIfFinish()) {
            setTimeout(() => {
                this.addState();
            }, this.refreshTimeoutSeconds * 1000);
        }
    }

    private addState = () => {
        let lastStep = this.history[this.history.length - 1];

        let speedPerTimeout = this.speedKph / this.refreshTimeoutSeconds * 60;
        let caloriesPerTimeout = this.caloriesBurnRate / this.refreshTimeoutSeconds;

        let newDuration = lastStep.duration + this.refreshTimeoutSeconds;
        let newDurationCountDown = lastStep.duration_countdown - this.refreshTimeoutSeconds;
        let percentege = newDuration * 100 / newDurationCountDown;

        let nextStep: WorkoutState = {
            ...lastStep,
            distance: lastStep.distance + speedPerTimeout,
            calories: lastStep.calories + caloriesPerTimeout,
            duration: newDuration,
            duration_countdown: newDurationCountDown,
            grade: percentege,
            pace: -1
        }

        this.registerStep(nextStep);
        this.triggerSyncing();
    }

    private flushTimerIfFinish = () => {
        let lastStep = this.history[this.history.length - 1];

        if (lastStep.duration_countdown == 0 || this._isDisposed) {
            this.onWorkoutEnd();
            return false;
        }

        return true;
    }
}