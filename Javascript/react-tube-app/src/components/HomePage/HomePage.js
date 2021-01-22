import '../../App.css'
import React from 'react';
import RelatedVideo from '../VideoPage/RelatedVideo'
import { withRouter } from "react-router";

import { CircularProgress } from '@material-ui/core';



class HomePage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    }

    async fetchRandomVideos() {
        const videos = await fetch('http://localhost:5000/api/v1/videos/')
            .then(response => response.json())
            .catch(err => { console.log(err); throw new Error(err); });
        this.setState({
            randomVideos: videos,
            loaded: true
        });
        console.log(videos);
    }

    componentDidMount() {
        this.fetchRandomVideos();
    }
    render() {

        let { loaded, randomVideos } = this.state;
        if (loaded)
            return (
                <div className="homePage">
                    {
                        randomVideos.map(function (v, index) {
                            console.log(v);
                            return <RelatedVideo url={"/video/" + v.id} title={v.name} views={v.views} channel={v.AuthorName} />;
                        })
                    }
                </div>

            );
        else
            return (<div className="loadingCircle" ><CircularProgress /></div>)
    }
}

export default withRouter(HomePage);