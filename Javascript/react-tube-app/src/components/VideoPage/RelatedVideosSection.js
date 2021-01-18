import '../../App.css';
import RelatedVideo from './RelatedVideo.js'

function RelatedVideosSection(props) {
    return (
        <div className="relatedVideos">
            <RelatedVideo thumb={props.thumb} />
            <RelatedVideo thumb={props.thumb} />
            <RelatedVideo thumb={props.thumb} />
            <RelatedVideo thumb={props.thumb} />
        </div>
    );
}

export default RelatedVideosSection;
