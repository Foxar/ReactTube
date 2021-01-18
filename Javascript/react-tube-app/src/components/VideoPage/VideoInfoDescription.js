import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { IconButton, TextField, Avatar } from '@material-ui/core';

function VideoInfoDescription(props) {

    if (props.desc)
        return (
            <div className="videoInfoDescription" style={{ width: props.width }}  >
                <p>
                    {props.desc}
                </p>
            </div>
        );
    else
        return (
            <div className="videoInfoDescription" style={{ width: props.width, fontStyle: 'italic' }}  >
                <p>
                    Description not available.
            </p>
            </div>
        );
}

export default VideoInfoDescription;
