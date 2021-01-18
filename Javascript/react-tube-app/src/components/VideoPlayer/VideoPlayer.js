import '../../App.css'
import React from 'react';
import ReactPlayer from 'react-player';
import { IconButton, LinearProgress } from '@material-ui/core';
import VideoControlPlayPause from './VideoControlPlayPause'
import { withRouter } from "react-router";


class VideoPlayer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            playing: false,
            played: 0,
            loaded: 0
        }
    }

    render() {

        const { url, width } = this.props;
        console.log(url);
        console.log(width);
        return (
            <div className="component_videoplayer">
                <ReactPlayer playing={this.state.playing} muted width={width} height='480px'
                    url={url}
                    progressInterval={100}
                    onProgress={(props) => {
                        this.setState(() => ({
                            played: props.played,
                            loaded: props.loaded
                        }));
                        console.log(this.state.played);
                    }} />
                <LinearProgress className="videoProgressBar" variant="buffer" value={this.state.played * 100} valueBuffer={this.state.loaded} />
                <div id="playbackbuttons">
                    <IconButton onClick={() => {
                        this.setState((state) => ({
                            playing: !state.playing
                        }));
                    }
                    }
                    >
                        <VideoControlPlayPause isPlaying={this.state.playing} />
                    </IconButton>
                </div>
            </div>
        )
    }
}

export default withRouter(VideoPlayer);