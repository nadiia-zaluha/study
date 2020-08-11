import { createHashHistory } from 'history';
import * as React from 'react';
import { render } from 'react-dom';
import { Provider } from "react-redux"
import { Layout } from "./layout"
import { Dashboard } from "./dashboard/dashboardTab"
import { buildStore } from "state/store"

start();

function start() {

    var errorNode = document.getElementById('errorblock');
    if (errorNode != null) {
        return;
    }

    var history = createHashHistory();
    var node = document.getElementsByTagName('body')[0];

    let store = buildStore();
    render(
        <Provider store={store}>
            <Dashboard/>
        </Provider>,
        node
    );
}
