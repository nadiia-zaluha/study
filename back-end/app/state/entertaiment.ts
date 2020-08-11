import { StateController } from "Utils/StateController"
import * as VideoService from "service/VideoService"

const state = new StateController<EntertaimentState>("ENTERTAIMENT");

class EntertaimentState {
    videos: Array<VideoService.Video>;
    selectedId: string;
}

const defaultState: EntertaimentState = {
    videos: VideoService.default.getVideos(),
    selectedId: null
}

class Service {
    public static selectVideo = (selectedVideoId: string) => {

    }
}

const reducer = state.getReducer();

export {
    reducer as Reducer,
    defaultState as DefaultState,
    EntertaimentState as State,
    Service as Service
};