import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { IconButton, TextField, Avatar } from '@material-ui/core';
import VideoInfoDescription from './VideoInfoDescription';

function VideoInfo(props) {
    const width = props.width;
    console.log("width");
    console.log(width);
    return (
        <div className="videoInfo">
            <h1>{props.name}</h1>
            <p>{props.views} views</p>
            <h5>11 January 2021</h5>
            <hr />
            <div className="uploaderInfo">
                <Avatar alt="User" ></Avatar>
                <h4>{props.author}</h4>
            </div>
            <VideoInfoDescription width={props.width} desc={props.desc} />
        </div>
    );
}

export default VideoInfo;
