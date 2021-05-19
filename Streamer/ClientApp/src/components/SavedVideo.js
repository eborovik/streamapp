import React from 'react';
import { VideoPlayer } from './VideoPlayer';
import SavedVideoOptions from './SavedVideoOptions';

export class SavedVideo extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        const videoJsOptions = {
            autoplay: true,
            controls: true,
            sources: [{
                src: this.props.url,
                type: 'application/x-mpegURL'
            }]
        }

        return (
            <div className="video">
                <p>{this.props.name}</p>

                <VideoPlayer {...videoJsOptions} />

                <SavedVideoOptions {...this.props} />
            </div>
        )
    }
}