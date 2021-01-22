import React from 'react';
import { TextareaAutosize } from "@material-ui/core";
import { TextField, Button } from '@material-ui/core';

class VideoUploadPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            title: '',
            description: '',
            AppUserId: ''
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        if (e.target.name == "videoTitle")
            this.setState({ title: e.target.value });
        else if (e.target.name == "desc")
            this.setState({ description: e.target.value });
        else if (e.target.name == "fileupload") {
            this.setState({ file: e.target.files[0] });
            console.log(e.target.value);
        }
    }

    handleSubmit(e) {
        var formdata = new FormData();
        formdata.append('name', this.state.title);
        formdata.append('desc', this.state.description);
        formdata.append('AppUserId', "asdfads");
        console.log(this.state);
        fetch('http://localhost:5000/api/v1/videos/', {
            method: 'POST',
            body: formdata
        })
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                var filePath = data.path;
                this.setState({
                    calledVideos: true
                });
                var fileformdata = new FormData();
                fileformdata.append('path', filePath);
                fileformdata.append('file', this.state.file);
                console.log("fetching with " + this.state.file);
                fetch('http://localhost:5000/api/v1/videofile', {
                    method: 'POST',
                    body: fileformdata
                }).then(() => {
                    this.setState({
                        uploadedVideo: true
                    });
                });
            });

        e.preventDefault();
    }

    render() {
        if (this.state.calledVideos) {
            console.log("Submitted video to database!");
        }
        if (this.state.uploadedVideo)
            console.log("Uploaded video");
        return (
            <div className="uploadPage">
                <div className="uploadForm">
                    <form className="uploadForm" onSubmit={this.handleSubmit}>
                        <h1> Upload Video</h1>
                        <TextField
                            name="videoTitle"
                            className="uploadInput"
                            label="Video title"
                            variant="filled"
                            onChange={this.handleChange}
                            required />
                        <TextareaAutosize
                            name="desc"
                            onChange={this.handleChange}
                            className="uploadInput"
                            rowsMax={40}
                            rowsMin={10}
                            defaultValue="Video description here..."
                            required />

                        <input
                            name="fileupload"
                            onChange={this.handleChange}
                            accept="video/*"
                            className="uploadInput"
                            id="contained-button-file"
                            type="file"
                            required
                        />
                        <label htmlFor="contained-button-file">
                            <Button className="uploadInput" variant="contained" color="secondary" component="span">
                                Upload
                            </Button>
                        </label>

                        <input
                            onChange={this.handleChange}
                            className="uploadInput"
                            id="contained-button-submit"
                            type="submit"
                        />
                        <label htmlFor="contained-button-submit">
                            <Button className="uploadInput" variant="contained" color="primary" component="span">
                                Submit
                            </Button>
                        </label>
                    </form>
                </div>
            </div>);
    }
}

export default VideoUploadPage;
