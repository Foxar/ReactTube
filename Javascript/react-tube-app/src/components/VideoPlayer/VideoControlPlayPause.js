import PlayArrowSharp from '@material-ui/icons/PlayArrowSharp';
import PauseCircleFilledSharpIcon from '@material-ui/icons/PauseCircleFilledSharp';

function VideoControlPlayPause(props) {
    if (props.isPlaying) {
        return <PauseCircleFilledSharpIcon />;
    } else {
        return <PlayArrowSharp />;
    }
}

export default VideoControlPlayPause;