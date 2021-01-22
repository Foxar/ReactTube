import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { IconButton, TextField, Avatar } from '@material-ui/core';
import VideoInfoDescription from './VideoInfoDescription';

function RelatedVideo(props) {
    console.log(props);
    if (props.url == null || props.title == null || props.views == null)
        return (
            <div className="relatedVideo">
                <a href="/video/7SXNeaGkn0GxZE5g0YblHg"><img className="relatedThumb" src="/videos/test3/thumb.jpg" /></a>
                <div className="relatedVideoInfo">
                    <h4>Video title</h4>
                    <p>channel</p>
                    <p>184k views</p>
                </div>
            </div>
        );
    else
        return (
            <div className="relatedVideo">
                <a href={props.url}><img className="relatedThumb" src="/videos/test3/thumb.jpg" /></a>
                <div className="relatedVideoInfo">
                    <h4>{props.title}</h4>
                    <p>{props.channel}</p>
                    <p>{props.views}</p>
                </div>
            </div>
        );

}

export default RelatedVideo;
