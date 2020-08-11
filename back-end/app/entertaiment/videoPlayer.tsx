
import * as React from "react"
import VideoService, { Video } from "service/VideoService"

export class StateProps {
    videoInfo: Video;
}

export class VideoPlayer extends React.Component<StateProps, {}> {

    private videoRef: HTMLVideoElement;

    componentDidMount() {
        this.videoRef.play();
    }

    render() {
        return <div>
            <video ref={(ref) => { this.videoRef = ref; }} width="320" height="176" controls>
                <source src={this.props.videoInfo.url} type={this.props.videoInfo.type} />
            </video>
        </div>
    }
}
