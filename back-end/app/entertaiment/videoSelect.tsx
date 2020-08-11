
import * as React from "react"
import VideoService, { Video } from "service/VideoService"

export class StateProps {
    videoInfo: Array<Video>;
    selectedId: string;
}

export class DispatchProps {
    onVideoSelect: (id: string) => void;
}

export class VideoSelect extends React.Component<StateProps, {}> {

    render() {
        return <div>
            TODO SELECT VIDEO
        </div>
    }
}
