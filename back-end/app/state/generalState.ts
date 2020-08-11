import { StateController } from "Utils/StateController"

const state = new StateController<GeneralState>("GENERAL");

class TabRegistry {
    public static Dashboard = "Dashboard";
    public static EntertaimentSelect = "EntertaimentSelect";
    public static EntertaimentView = "EntertaimentView";
}

class GeneralState {
    selectedTab: string;
}

const defaultState: GeneralState = {
    selectedTab: TabRegistry.Dashboard,
}

class Service {
    public static toggleTab = (tabId: string) => {

    }
}

const reducer = state.getReducer();

export {
    reducer as Reducer,
    defaultState as DefaultState,
    GeneralState as State,
    Service as Service
};