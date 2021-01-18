import '../../App.css'
import React from 'react';
import VideoPlayer from '../VideoPlayer/VideoPlayer'
import { withRouter } from "react-router";
import VideoInfo from './VideoInfo';
import RelatedVideosSection from './RelatedVideosSection';
import { CircularProgress } from '@material-ui/core';



class VideoPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            videoWidth: 1280,
            loading: false
        }
    }
    static defaultProps = {

    }

    async fetchVideoAndUser() {
        const video = await fetch('http://localhost:5000/api/v1/videos/' + this.props.match.params.urlName)
            .then(response => response.json())
            .catch(err => { console.log(err); throw new Error(err); });
        this.setState({
            path: video.path,
            name: video.name,
            desc: video.desc,
            authorid: video.userId,
            views: video.views.toLocaleString(),
            tempRelatedThumb: video.thumbnailPath
        });
        const user = await fetch('http://localhost:5000/api/v1/users/' + video.userId).then(response => response.json());
        this.setState({
            authorname: user.name,
            loaded: true
        });
        console.log(user);

    }


    componentDidMount() {
        this.fetchVideoAndUser();

    }

    render() {

        let { loaded, path, name, desc, videoWidth, views, tempRelatedThumb, authorname } = this.state;
        if (loaded)
            return (
                <div className="videoPage">
                    <div className="videoSection">
                        <VideoPlayer width={videoWidth + "px"} url={path} />
                        <VideoInfo width={videoWidth + "px"} name={name} desc={desc} views={views}
                            author={authorname} />
                        <hr />
                        <h4>Comments</h4>
                    </div>
                    <RelatedVideosSection thumb={tempRelatedThumb} />
                </div>
            );
        else
            return (<div className="loadingCircle" ><CircularProgress /></div>)
    }
}

export default withRouter(VideoPage);