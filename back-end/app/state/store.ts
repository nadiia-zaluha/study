import { createStore, applyMiddleware, compose, combineReducers } from 'redux';
import thunk from 'redux-thunk';

import * as workout from "./workout"

export class AppStore{
    workout: workout.State;
}

let defaultState:AppStore ={
    workout: workout.DefaultState
}

export function buildStore()
{
    let combinedReducers = {
        workout: workout.Reducer
    };
    
    return createStore(
        combineReducers(combinedReducers),
        defaultState,
        compose(
            applyMiddleware(
                thunk
            ),
            window["devToolsExtension"] ? window["devToolsExtension"]({ trace: true }) : f => f
        )
    );
}