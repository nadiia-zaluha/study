export class StateController<State> {

    private name: string;
    private extenssion = '__pick';

    constructor(name: string) {
        this.name = name;
    }

    public setState<K extends keyof State>(state: ((state: State) => State) | (Pick<State, K> | State)) {

        let pickExtenssion = typeof (state) === 'function' ? '' : this.extenssion;

        return {
            type: this.name + pickExtenssion,
            payload: state
        };
    }

    public getReducer() {
        return (state, action) => {
            let stateForMutation: State = { ...state };
            if (action.type == this.name) {
                let mutateState = action.payload as (state: State) => State;
                stateForMutation = mutateState(state);
            }

            if (action.type == this.name + this.extenssion) {
                stateForMutation = { ...state, ...action.payload };
            }

            return stateForMutation;
        }
    }
}