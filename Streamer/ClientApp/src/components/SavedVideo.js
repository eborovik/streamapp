import React from 'react';
import {ReactFlvPlayer} from 'react-flv-player'
import SavedVideoOptions from './SavedVideoOptions';

export class SavedVideo extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        
        return (
            <div className="video">
                <p>{this.props.name}</p>

                <ReactFlvPlayer url = {this.props.videoUrl}  height="200px" />               

                <SavedVideoOptions {...this.props} />
            </div>
        )
    }
}