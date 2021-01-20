import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { IconButton, TextField, Avatar } from '@material-ui/core';
import VideoInfoDescription from './VideoInfoDescription';

function RelatedVideo(props) {
    return (
        <div className="relatedVideo">
            <a href="/video/7SXNeaGkn0GxZE5g0YblHg"><img className="relatedThumb" src={props.thumb} /></a>
            <div className="relatedVideoInfo">
                <h4>Video title</h4>
                <p>channel</p>
                <p>184k views</p>
            </div>
        </div>
    );
}

export default RelatedVideo;
